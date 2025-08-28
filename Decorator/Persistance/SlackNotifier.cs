using Decorator.Abstractions;

namespace Decorator.Persistance
{
    public class SlackNotifier : NotifierDecorator
    {
        public SlackNotifier(INotifier wrappee) : base(wrappee) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending Slack: {message}");
        }
    }
}
