using static ServiceController.Pinvoke;

namespace ServiceController
{
    public struct Driver
    {
        public string BaseAddress { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
    public class DriverManager
    {
        public IEnumerable<Driver> EnumDrivers()
        {
            var drivers = new List<Driver>();
            var driverHandles = new nint[2048];
            if (!K32EnumDeviceDrivers(driverHandles, (uint)(nint.Size * driverHandles.Length), out var bytesNeeded))
            {
                Utils.PrintLastError("K32EnumDeviceDrivers");
                return drivers;
            }


            if (bytesNeeded > driverHandles.Length)
            {
                Console.WriteLine($"More memory than {driverHandles.Length} is needed. Allocating {bytesNeeded}");
                driverHandles = new nint[bytesNeeded];
            }

            if (K32EnumDeviceDrivers(driverHandles, bytesNeeded, out bytesNeeded))
            {
                var numDrivers = (int)(bytesNeeded / nint.Size);

                for (var i = 0; i < numDrivers; i++)
                {
                    var driverHandle = driverHandles[i];
                    var fileName = new char[256];
                    var baseName = new char[256];

                    if (K32GetDeviceDriverBaseName(driverHandle, baseName, baseName.Length) == 0)
                    {
                        Utils.PrintLastError("K32GetDeviceDriverBaseName");
                        return drivers;

                    }

                    if (GetDeviceDriverFileName(driverHandle, fileName, fileName.Length) == false)
                    {
                        Utils.PrintLastError("GetDeviceDriverFileName");
                        return drivers;
                    }

                    {
                        drivers.Add(new Driver
                        {
                            BaseAddress = driverHandle.ToInt64().ToString("x"),
                            Name = new string(fileName).Replace("\0", string.Empty),
                            Path = new string(baseName).Replace("\0", string.Empty),
                        });
                    }
                }
            }
            else
            {
                Utils.PrintLastError("K32EnumDeviceDrivers");
                return drivers;
            }

            return drivers;
        }
    }
}