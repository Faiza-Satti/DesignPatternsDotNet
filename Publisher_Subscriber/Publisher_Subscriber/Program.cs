using Publisher_Subscriber.Abstractions;
using Publisher_Subscriber.Queue;

IMessagePublisher publisher = new RabbitMqPublisher();
IMessageSubscriber subscriber1 = new RabbitMqSubscriber();
IMessageSubscriber subscriber2 = new RabbitMqSubscriber();

// Run subscribers on different threads
Task.Run(() =>
{
    subscriber1.Subscribe("news.sports.*", msg =>
    {
        Console.WriteLine($" [Sports Sub] {msg}");
    });
});

Task.Run(() =>
{
    subscriber2.Subscribe("news.weather.#", msg =>
    {
        Console.WriteLine($" [Weather Sub] {msg}");
    });
});

// Publisher loop in main thread
while (true)
{
    Console.Write("Enter topic: ");
    var topic = Console.ReadLine();

    Console.Write("Enter message: ");
    var message = Console.ReadLine();

    publisher.Publish(topic, message);
}