
using static ServiceController.Pinvoke;
namespace ServiceController
{
    public static class Utils
    {
        public static void PrintLastError(string message)
        {
            Console.WriteLine($"[+] {message}");
            Console.WriteLine($"[+] GetLastError: {GetLastError()}");
        }
    }
}
