using System;
using System.Threading.Tasks;
using Tmds.DBus;
using UPower.DBus;

namespace demo4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Waiting for device. Press Ctrl-C to stop.");

            IUPower power = Connection.System.CreateProxy<IUPower>("org.freedesktop.UPower", "/org/freedesktop/UPower");
            await power.WatchDeviceAddedAsync(path => Console.WriteLine($"Device connected: {path}"));

            await Task.Delay(-1);
        }
    }
}
