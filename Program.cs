using System;
using System.Threading.Tasks;
using Tmds.DBus;
using UPower.DBus;

namespace demo4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            PrintNewDevices().Wait();
        }

        static async Task PrintNewDevices()
        {
            using( var connection = new Connection(Address.System) )
            {
                await connection.ConnectAsync();
                IUPower power = connection.CreateProxy<IUPower>("org.freedesktop.UPower", "/org/freedesktop/UPower");

                await power.WatchDeviceAddedAsync(devicePath => {
                    Console.WriteLine("Device connected: "+ devicePath.ToString());
                });

                await Task.Run(() => {
                    Console.WriteLine("Waiting for device... (Press any key to close the application.)");
                    Console.ReadKey();
                    Console.WriteLine();
                });
            }
        }
    }
}
