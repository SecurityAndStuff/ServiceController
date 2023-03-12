using System.Runtime.InteropServices;

namespace ServiceController
{
    public static class Pinvoke
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool K32EnumDeviceDrivers(
            [Out] nint[] lpImageBase,
            uint cb,
            [Out] out uint lpcbNeeded
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint K32GetDeviceDriverBaseName(
            nint ImageBase,
            [Out] char[] lpBaseName,
            int nSize
        );

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern bool GetDeviceDriverFileName(
            nint ImageBase,
            [Out] char[] lpFilename,
            int nSize
        );


        public const int SC_ENUM_PROCESS_INFO = 0;

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnumServicesStatusEx(IntPtr hSCManager,
            int infoLevel, int dwServiceType,
            int dwServiceState, IntPtr lpServices, uint cbBufSize,
            out uint pcbBytesNeeded, out uint lpServicesReturned,
            ref uint lpResumeHandle, string? pszGroupName);

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct ENUM_SERVICE_STATUS_PROCESS
        {
            internal static readonly int SizePack4 = Marshal.SizeOf(typeof(ENUM_SERVICE_STATUS_PROCESS));

            /// <summary>
            /// sizeof(ENUM_SERVICE_STATUS_PROCESS) allow Packing of 8 on 64 bit machines
            /// </summary>
            internal static readonly int SizePack8 = Marshal.SizeOf(typeof(ENUM_SERVICE_STATUS_PROCESS)) + 4;

            [MarshalAs(UnmanagedType.LPWStr)] internal string pServiceName;

            [MarshalAs(UnmanagedType.LPWStr)] internal string pDisplayName;

            internal SERVICE_STATUS_PROCESS ServiceStatus;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SERVICE_STATUS_PROCESS
        {
            public int serviceType;
            public int currentState;
            public int controlsAccepted;
            public int win32ExitCode;
            public int serviceSpecificExitCode;
            public int checkPoint;
            public int waitHint;
            public int processId;
            public int serviceFlags;
        }

        [Flags]
        public enum ServiceType
        {
            SERVICE_KERNEL_DRIVER = 0x1,
            SERVICE_FILE_SYSTEM_DRIVER = 0x2,
            SERVICE_WIN32_OWN_PROCESS = 0x10,
            SERVICE_WIN32_SHARE_PROCESS = 0x20,
            SERVICE_INTERACTIVE_PROCESS = 0x100,
            SERVICE_WIN32 = SERVICE_WIN32_OWN_PROCESS | SERVICE_WIN32_SHARE_PROCESS
        }

        public enum ServiceStateRequest
        {
            SERVICE_ACTIVE = 0x1,
            SERVICE_INACTIVE = 0x2,
            SERVICE_STATE_ALL = SERVICE_ACTIVE | SERVICE_INACTIVE
        }

        public enum ServiceControlManagerType
        {
            SC_MANAGER_CONNECT = 0x1,
            SC_MANAGER_CREATE_SERVICE = 0x2,
            SC_MANAGER_ENUMERATE_SERVICE = 0x4,
            SC_MANAGER_LOCK = 0x8,
            SC_MANAGER_QUERY_LOCK_STATUS = 0x10,
            SC_MANAGER_MODIFY_BOOT_CONFIG = 0x20,

            SC_MANAGER_ALL_ACCESS = SC_MANAGER_CONNECT | SC_MANAGER_CREATE_SERVICE |
                                    SC_MANAGER_ENUMERATE_SERVICE | SC_MANAGER_LOCK | SC_MANAGER_QUERY_LOCK_STATUS |
                                    SC_MANAGER_MODIFY_BOOT_CONFIG
        }

        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern IntPtr OpenSCManager(string? machineName, string? databaseName, uint dwAccess);



        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseServiceHandle(IntPtr hSCObject);

        [DllImport("advapi32.dll", EntryPoint = "OpenServiceA", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName,
            SERVICE_ACCESS dwDesiredAccess);

        [Flags]
        public enum SERVICE_ACCESS : uint
        {
            STANDARD_RIGHTS_REQUIRED = 0xF0000,
            SERVICE_QUERY_CONFIG = 0x00001,
            SERVICE_CHANGE_CONFIG = 0x00002,
            SERVICE_QUERY_STATUS = 0x00004,
            SERVICE_ENUMERATE_DEPENDENTS = 0x00008,
            SERVICE_START = 0x00010,
            SERVICE_STOP = 0x00020,
            SERVICE_PAUSE_CONTINUE = 0x00040,
            SERVICE_INTERROGATE = 0x00080,
            SERVICE_USER_DEFINED_CONTROL = 0x00100,

            SERVICE_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED |
                                  SERVICE_QUERY_CONFIG |
                                  SERVICE_CHANGE_CONFIG |
                                  SERVICE_QUERY_STATUS |
                                  SERVICE_ENUMERATE_DEPENDENTS |
                                  SERVICE_START |
                                  SERVICE_STOP |
                                  SERVICE_PAUSE_CONTINUE |
                                  SERVICE_INTERROGATE |
                                  SERVICE_USER_DEFINED_CONTROL)
        }
        [DllImport("advapi32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StartService(
            IntPtr hService,
            int dwNumServiceArgs,
            string[]? lpServiceArgVectors
        );

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ControlService(IntPtr hService, SERVICE_CONTROL dwControl, ref SERVICE_STATUS lpServiceStatus);
        [Flags]
        public enum SERVICE_TYPES : int
        {
            SERVICE_KERNEL_DRIVER = 0x00000001,
            SERVICE_FILE_SYSTEM_DRIVER = 0x00000002,
            SERVICE_WIN32_OWN_PROCESS = 0x00000010,
            SERVICE_WIN32_SHARE_PROCESS = 0x00000020,
            SERVICE_INTERACTIVE_PROCESS = 0x00000100
        }
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct SERVICE_STATUS
        {
            public SERVICE_TYPES dwServiceType;
            public SERVICE_STATE dwCurrentState;
            public uint dwControlsAccepted;
            public uint dwWin32ExitCode;
            public uint dwServiceSpecificExitCode;
            public uint dwCheckPoint;
            public uint dwWaitHint;
        }

        [Flags]
        public enum SERVICE_CONTROL : uint
        {
            STOP = 0x00000001,
            PAUSE = 0x00000002,
            CONTINUE = 0x00000003,
            INTERROGATE = 0x00000004,
            SHUTDOWN = 0x00000005,
            PARAMCHANGE = 0x00000006,
            NETBINDADD = 0x00000007,
            NETBINDREMOVE = 0x00000008,
            NETBINDENABLE = 0x00000009,
            NETBINDDISABLE = 0x0000000A,
            DEVICEEVENT = 0x0000000B,
            HARDWAREPROFILECHANGE = 0x0000000C,
            POWEREVENT = 0x0000000D,
            SESSIONCHANGE = 0x0000000E
        }

        public enum SERVICE_STATE : uint
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007
        }

        [Flags]
        public enum SERVICE_ACCEPT : uint
        {
            STOP = 0x00000001,
            PAUSE_CONTINUE = 0x00000002,
            SHUTDOWN = 0x00000004,
            PARAMCHANGE = 0x00000008,
            NETBINDCHANGE = 0x00000010,
            HARDWAREPROFILECHANGE = 0x00000020,
            POWEREVENT = 0x00000040,
            SESSIONCHANGE = 0x00000080,
        }
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteService(IntPtr hService);
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateService(
            IntPtr hSCManager,
            string lpServiceName,
            string lpDisplayName,
            uint dwDesiredAccess,
            uint dwServiceType,
            uint dwStartType,
            uint dwErrorControl,
            string lpBinaryPathName,
            [Optional] string? lpLoadOrderGroup,
            [Optional] string lpdwTagId,    // only string so we can pass null
            [Optional] string lpDependencies,
            [Optional] string lpServiceStartName,
            [Optional] string? lpPassword);

        public const int STANDARD_RIGHTS_REQUIRED = 0xF0000;

        public const int SERVICE_AUTO_START = 0x2;
        public const int SERVICE_DEMAND_START = 0x3;
        public const int SERVICE_DISABLED = 0x4;
        public const int SERVICE_ERROR_NORMAL = 0x1;
        public const int SERVICE_WIN32_OWN_PROCESS = 0x10;
        public const int SERVICE_QUERY_CONFIG = 0x1;
        public const int SERVICE_CHANGE_CONFIG = 0x2;
        public const int SERVICE_QUERY_STATUS = 0x4;
        public const int SERVICE_ENUMERATE_DEPENDENTS = 0x8;
        public const int SERVICE_START = 0x10;
        public const int SERVICE_STOP = 0x20;
        public const int SERVICE_PAUSE_CONTINUE = 0x40;
        public const int SERVICE_INTERROGATE = 0x80;
        public const int SERVICE_USER_DEFINED_CONTROL = 0x100;
        public const int SERVICE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
                                               SERVICE_QUERY_CONFIG |
                                               SERVICE_CHANGE_CONFIG |
                                               SERVICE_QUERY_STATUS |
                                               SERVICE_ENUMERATE_DEPENDENTS |
                                               SERVICE_START |
                                               SERVICE_STOP |
                                               SERVICE_PAUSE_CONTINUE |
                                               SERVICE_INTERROGATE |
                                               SERVICE_USER_DEFINED_CONTROL;
    }

}