using System.Threading.Tasks;

namespace TheKrystalShip.Polly.Extensions
{
    public static class TaskExtensions
    {
        public static async Task DelayIndefinetly(this Task task)
        {
            await Task.Delay(-1);
        }
    }
}
