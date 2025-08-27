namespace Publisher_Subscriber.Abstractions
{
    public interface IMessagePublisher
    {
        void Publish(string topic, string message);
    }

    public interface IMessageSubscriber
    {
        void Subscribe(string topicPattern, Action<string> onMessageReceived);
    }

}
