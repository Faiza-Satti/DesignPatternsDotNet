using Observer.Abstractions;

namespace Observer.Core
{
    // Concrete Observers
    public class SportsSubscriber : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[Sports Subscriber] Received: {message}");
        }
    }
}
