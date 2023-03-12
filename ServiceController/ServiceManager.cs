using System.Runtime.InteropServices;
using static ServiceController.Pinvoke;

namespace ServiceController
{
    public struct Service
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    public class ServiceManager
    {

        public ServiceManager()
        {
            _scmHandle = nint.Zero;
            _buffer = nint.Zero;
            _serviceHandle = nint.Zero;
            _scmHandle = OpenSCManager(null, null, (int)ServiceControlManagerType.SC_MANAGER_ALL_ACCESS);
            if (_scmHandle != nint.Zero) return;
            Utils.PrintLastError("OpenSCManager");
            throw new Exception("Failed to initialize");
        }


        ~ServiceManager()
        {
            if (_scmHandle != 0)
            {
                CloseServiceHandle(_scmHandle);
            }

            if (_serviceHandle != 0)
            {
                CloseServiceHandle(_serviceHandle);
            }

            if (_buffer != 0)
            {
                Marshal.FreeHGlobal(_buffer);
            }
        }

        private nint _scmHandle;
        private nint _buffer;
        private nint _serviceHandle;

        // https://www.pinvoke.net/default.aspx/advapi32.enumservicesstatus
        public List<Service> EnumServices()
        {
            var servicesList = new List<Service>();
            _buffer = nint.Zero;
            uint resumeHandle = 0;

            if (EnumServicesStatusEx(_scmHandle, SC_ENUM_PROCESS_INFO, (int)(ServiceType.SERVICE_KERNEL_DRIVER | ServiceType.SERVICE_INTERACTIVE_PROCESS | ServiceType.SERVICE_WIN32 | ServiceType.SERVICE_WIN32_OWN_PROCESS | ServiceType.SERVICE_WIN32_SHARE_PROCESS),
                    (int)ServiceStateRequest.SERVICE_STATE_ALL, nint.Zero, 0, out var bytesNeeded,
                    out var iServicesReturned, ref resumeHandle, null)) return servicesList;
            _buffer = Marshal.AllocHGlobal((int)bytesNeeded);

            if (!EnumServicesStatusEx(_scmHandle, SC_ENUM_PROCESS_INFO, (int)(ServiceType.SERVICE_KERNEL_DRIVER | ServiceType.SERVICE_INTERACTIVE_PROCESS | ServiceType.SERVICE_WIN32 | ServiceType.SERVICE_WIN32_OWN_PROCESS | ServiceType.SERVICE_WIN32_SHARE_PROCESS),
                    (int)ServiceStateRequest.SERVICE_STATE_ALL, _buffer, bytesNeeded, out bytesNeeded,
                    out iServicesReturned, ref resumeHandle, null))
            {
                Utils.PrintLastError("EnumServicesStatusEx");
                return servicesList;
            }

            if (nint.Size != 8) return servicesList;

            var pointer = _buffer.ToInt64();
            for (var i = 0; i < (int)iServicesReturned; i++)
            {
                var serviceStatusProcess = (ENUM_SERVICE_STATUS_PROCESS)(Marshal.PtrToStructure(new nint(pointer),
                    typeof(ENUM_SERVICE_STATUS_PROCESS)) ?? throw new InvalidOperationException());

                servicesList.Add(new Service
                {
                    Name = serviceStatusProcess.pServiceName,
                    DisplayName = serviceStatusProcess.pDisplayName,
                });
                pointer += ENUM_SERVICE_STATUS_PROCESS.SizePack8;
            }
            return servicesList;

        }

        public bool StartService(string serviceName)
        {
            if (string.IsNullOrWhiteSpace(serviceName)) return false;
            if (_scmHandle == 0) return false;
            _serviceHandle = OpenService(_scmHandle, serviceName, SERVICE_ACCESS.SERVICE_START);
            if (_serviceHandle == 0)
            {
                Utils.PrintLastError("OpenService");
                return false;
            }

            if (Pinvoke.StartService(_serviceHandle, 0, null))
            {
                CloseServiceHandle(_serviceHandle);
                _serviceHandle = 0;
                Utils.PrintLastError("StartService");
                return false;
            }
            CloseServiceHandle(_serviceHandle);
            _serviceHandle = 0;
            return true;
        }

        public bool StopService(string serviceName)
        {
            if (string.IsNullOrWhiteSpace(serviceName)) return false;
            if (_scmHandle == 0) return false;
            _serviceHandle = OpenService(_scmHandle, serviceName, SERVICE_ACCESS.SERVICE_ALL_ACCESS);
            if (_serviceHandle == 0)
            {
                Utils.PrintLastError("OpenService");
                return false;
            }

            SERVICE_STATUS status = new SERVICE_STATUS();
            if (!ControlService(_serviceHandle, SERVICE_CONTROL.STOP, ref status))
            {
                CloseServiceHandle(_serviceHandle);
                _serviceHandle = 0;
                Utils.PrintLastError("ControlService");
                Console.WriteLine(status);
                return false;
            }

            Console.WriteLine(status);
            CloseServiceHandle(_serviceHandle);
            _serviceHandle = 0;
            return true;
        }

        public bool DeleteService(string serviceName)
        {
            if (string.IsNullOrWhiteSpace(serviceName)) return false;
            if (_scmHandle == 0) return false;
            _serviceHandle = OpenService(_scmHandle, serviceName, SERVICE_ACCESS.SERVICE_ALL_ACCESS);
            if (_serviceHandle == 0)
            {
                Utils.PrintLastError("OpenService");
                return false;
            }

            SERVICE_STATUS status = new SERVICE_STATUS();
            if (!Pinvoke.DeleteService(_serviceHandle))
            {
                CloseServiceHandle(_serviceHandle);
                _serviceHandle = 0;
                Utils.PrintLastError("ControlService");
                Console.WriteLine(status);
                return false;
            }

            Console.WriteLine(status);
            CloseServiceHandle(_serviceHandle);
            _serviceHandle = 0;
            return true;
        }

        public bool CreateService(string name,
            string description,
            SERVICE_ACCESS access,
            ServiceType serviceType,
            uint startType,
            int errorControl,
            string binaryPath,
            string? _,
            string? tagId,
            string dependencies,
            string serviceStartName,
            string? password
            )
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (string.IsNullOrWhiteSpace(description)) return false;
            if (string.IsNullOrWhiteSpace(binaryPath)) return false;
            if (_scmHandle == 0) return false;
            var serviceHandle = Pinvoke.CreateService(
                _scmHandle,
                name,
                description,
                (uint)access,
                (uint)serviceType,
                startType,
                0,
                binaryPath,
                null,
                null,
                dependencies
            );
            if (serviceHandle == 0)
            {
                Utils.PrintLastError("CreateService");
                return false;
            }

            CloseServiceHandle(serviceHandle);
            return true;
        }
    }
}