# Observer Pattern in .NET

## Overview
The **Observer Pattern** is a **behavioral design pattern** that establishes a **one-to-many relationship** between objects.  
When the **Subject** (the observable) changes its state, all of its **Observers** are automatically notified and updated.

This is particularly useful in systems where multiple parts of the application need to stay in sync without being tightly coupled.

---

## Why Use Observer Pattern?
- Eliminates tight coupling between objects.  
- Makes it easy to add new observers without modifying the subject.  
- Encourages an **event-driven architecture** inside applications.  
- Provides a **clean separation of concerns**.  

---

## Key Benefits
- Loose Coupling → Subject and observers interact via interfaces, not concrete types.
- Reusability → Observers can be reused with different subjects.
- Scalability → New observers can be added without modifying existing code.
- Flexibility → Different observers can react differently to the same event.

## Real-World Application
- UI Frameworks – Button click events notifying multiple handlers.
- Stock Market Apps – Investors (observers) are notified of price changes (subject).
- Chat Applications – Users subscribed to a channel receive messages.
- Logging Systems – Application events pushed to multiple outputs (file, console, database).
- Data Binding – WPF, MVVM patterns.

## Observer vs. Publisher-Subscriber

| Feature       | Observer Pattern                       | Pub/Sub Pattern                          |
| ------------- | -------------------------------------- | ---------------------------------------- |
| Scope         | In-process communication               | Distributed systems (via broker)         |
| Coupling      | Subject knows observers via interfaces | Publisher & Subscriber fully decoupled   |
| Broker        | Not required                           | Requires broker (RabbitMQ, Kafka, etc.)  |
| Communication | Synchronous (usually)                  | Asynchronous                             |
| Best For      | Local app state updates                | Microservices, event-driven architecture |
