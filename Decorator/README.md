# Decorator Pattern in .NET

## Overview
The **Decorator Pattern** is a **structural design pattern** that allows behavior to be added to an object dynamically, without modifying its class.  

Instead of creating a large inheritance tree, the pattern uses **composition**:  
- A base component defines the core interface.  
- Concrete components implement the base behavior.  
- Decorators wrap components to extend or modify behavior.  

---

## Why Use the Decorator Pattern?
- Avoids **class explosion** from too many subclasses.  
- Adds new functionality **dynamically at runtime**.  
- Promotes **open/closed principle** → classes are open for extension but closed for modification.  
- Useful when you want to stack multiple behaviors.  

---

## Structure

```mermaid
classDiagram
    class INotifier {
        +Send(string message)
    }

    class EmailNotifier {
        +Send(string message)
    }

    class NotifierDecorator {
        -INotifier _wrappee
        +Send(string message)
    }

    class SMSNotifier {
        +Send(string message)
    }

    class SlackNotifier {
        +Send(string message)
    }

    INotifier <|.. EmailNotifier
    INotifier <|.. NotifierDecorator
    NotifierDecorator <|-- SMSNotifier
    NotifierDecorator <|-- SlackNotifier
    NotifierDecorator --> INotifier
```

## Components
- Component (INotifier) → Common interface for all notifiers.
- Concrete Component (EmailNotifier) → Base implementation.
- Decorator (NotifierDecorator) → Wraps a component.
- Concrete Decorators (SMSNotifier, SlackNotifier) → Add extra behavior.

## Benefits
- Flexible → Add/remove functionality at runtime.
- Composable → Multiple decorators can be stacked.
- Open/Closed Principle → Extend behavior without touching base class.

## Real-World Application
- Logging → Wrap services to log method calls.
- Caching → Wrap database queries with a caching decorator.
- Authentication → Wrap services with permission checks.
- UI Frameworks → Scrollbars, borders, shadows are decorators around components.

- ## Decorator vs. Inheritance
| Aspect              | Inheritance                       | Decorator                           |
| ------------------- | --------------------------------- | ----------------------------------- |
| Flexibility         | Fixed at compile-time             | Dynamic at runtime                  |
| Class Explosion     | Many subclasses needed            | Only a few decorators, reusable     |
| Extension Mechanism | Extend by creating new subclasses | Extend by wrapping existing objects |
