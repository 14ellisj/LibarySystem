---
status: "Accepted"
date: {2025-01-03}
---

# Choosing an architecture for the project

## Context and Problem Statement

The architecture of our system needs to be able to account for a considerable increase in users year on year. The system is also made up of multiple parts so we should be prepared for further feature requirements as there become more users.


## Decision Drivers

* Facing concern of scalability
* Facing concern of security

## Considered Options

* Service Oriented
* Micro services
* Event Driven

## Decision Outcome

Chosen option: "Service Oriented", because 

## Pros and Cons of the Options

### Service Oriented
[Pros and Cons](https://www.geeksforgeeks.org/service-oriented-architecture/)

* Good, because services should be focussed so more maintainable
* Good, because you should be able to scale by business function
* Good, because if one service goes down only services that use it should be affected
* Good, because it allows you to break down system into business functions
* Good, because services should be focussed making it easier for developers to understand
* Bad, because lots of interactions between services results in slow downs and additional costs
* Bad, because making changes to a service will affect lots of things and is hard to track

### Micro services
[Pros and Cons](https://www.qa.com/resources/blog/microservices-architecture-challenge-advantage-drawback/)

* Good, because each service is scalabale
* Good, because any errors should be relatively isolated
* Good, because services are very focussed so easy to understand
* Bad, because can become incredibly complex with interactions
* Bad, because lots of services to track
* Bad, because individual databases for services means data may take time to become consistent
* Bad, because multiple sources of the truth

### Event Driven
[Pros and Cons](https://solace.com/blog/event-driven-architecture-pros-and-cons/)

* Good, because if a downstream function stops working then others will still continue
* Good, because it is easy to add new features to the architecture
* Good, because loose coupling makes the code scalable
* Bad, because finding issues and testing can be difficult as finding the origins of a problem is hard
* Bad, because it's harder to understand the monitor issues due to very loosely coupled nature
* Bad, because it will eventually become complex with multiple producers / consumers
