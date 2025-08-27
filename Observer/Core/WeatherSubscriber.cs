using Observer.Abstractions;

namespace Observer.Core
{
    // Concrete Observers
    public class WeatherSubscriber : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[Weather Subscriber] Received: {message}");
        }
    }
}
