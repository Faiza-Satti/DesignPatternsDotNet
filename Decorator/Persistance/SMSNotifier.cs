using Decorator.Abstractions;

namespace Decorator.Persistance
{
    // Concrete Decorators
    public class SMSNotifier : NotifierDecorator
    {
        public SMSNotifier(INotifier wrappee) : base(wrappee) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

}
