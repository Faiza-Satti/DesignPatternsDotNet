using Decorator.Abstractions;

namespace Decorator.Persistance
{
    // Base Decorator
    public abstract class NotifierDecorator : INotifier
    {
        protected readonly INotifier _wrappee;

        protected NotifierDecorator(INotifier wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual void Send(string message)
        {
            _wrappee.Send(message);
        }
    }
}
