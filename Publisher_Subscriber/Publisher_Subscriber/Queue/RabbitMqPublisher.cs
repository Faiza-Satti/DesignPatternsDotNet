using System.Text;
using Publisher_Subscriber.Abstractions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Publisher_Subscriber.Queue
{
    public class RabbitMqPublisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName = "topic_logs";

        public RabbitMqPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Topic);
        }

        public void Publish(string topic, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: _exchangeName, routingKey: topic, basicProperties: null, body: body);
            Console.WriteLine($" \n[x] Published: '{topic}':'{message}'");
        }
    }

    public class RabbitMqSubscriber : IMessageSubscriber
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName = "topic_logs";

        public RabbitMqSubscriber()
        {
            var factory = new ConnectionFactory() { 
                HostName = "localhost",
                UserName = ConnectionFactory.DefaultUser,
                Password = ConnectionFactory.DefaultPass
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Topic);
        }

        public void Subscribe(string topicPattern, Action<string> onMessageReceived)
        {
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: _exchangeName, routingKey: topicPattern);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine($" \n[x] Received on '{ea.RoutingKey}': {message}");
                onMessageReceived(message);
            };

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            Console.WriteLine($" \n[*] Subscribed to '{topicPattern}'");
        }
    }
}
