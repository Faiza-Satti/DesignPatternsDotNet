namespace Singelton.Model
{
    public interface IAppLogger
    {
        void Log(string message);
        Guid InstanceId { get; }
    }

    public sealed class AppLogger : IAppLogger
    {
        private static readonly Lazy<AppLogger> _instance =
            new Lazy<AppLogger>(() => new AppLogger());

        private readonly Guid _instanceId;

        private AppLogger()
        {
            _instanceId = Guid.NewGuid();
            Console.WriteLine($"AppLogger Singleton created! InstanceId = {_instanceId}");
        }

        public static AppLogger Instance => _instance.Value;

        public Guid InstanceId => _instanceId;

        public void Log(string message)
        {
            Console.WriteLine($"[LOG - {_instanceId}]: {message}");
        }
    }


}
