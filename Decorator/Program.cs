using Decorator.Abstractions;
using Decorator.Persistance;

INotifier notifier = new EmailNotifier();

// Wrap with SMS decorator
notifier = new SMSNotifier(notifier);

// Wrap with Slack decorator
notifier = new SlackNotifier(notifier);

notifier.Send("System down! Immediate action required.");