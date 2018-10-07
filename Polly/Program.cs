using System;
using System.Threading.Tasks;

using TheKrystalShip.Polly.Extensions;

namespace TheKrystalShip.Polly
{
    public class Program
    {
        private static Bot _polly;

        public static async Task Main(string[] args)
        {
            await (_polly = new Bot())
                .InitAsync()
                .DelayIndefinetly();
        }
    }
}
