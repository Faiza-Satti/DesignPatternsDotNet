using Decorator.Abstractions;

namespace Decorator.Persistance
{// Concrete Component
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }
}
