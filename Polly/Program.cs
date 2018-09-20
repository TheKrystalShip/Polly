using Discord;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Threading.Tasks;

using TheKrystalShip.Configuration;
using TheKrystalShip.Polly.Extensions;
using TheKrystalShip.Polly.Handlers;

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
