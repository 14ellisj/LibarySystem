---
# These are optional metadata elements. Feel free to remove any of them.
status: "Accepted"
date: 2024-12-11
---

# We are using an N-Tier code architecture in our services

## Context and Problem Statement

We realised the code was going to get messy quickly after creating our first endpoint. All the logic was in the contorller which made it hard to share common functionality. We also found that unit testing was difficult due to the lack of ability to mock dependencies and focus on specific units of code.

## Considered Options

* N-Tier
* Monolithic
* Clean

## Decision Outcome

Chosen option: "N-Tier", because the size of our services should be relatively small, meaning the additional files wont cause too much of an issue. If it becomes unmangeable it would also be a sign that the service needs splitting out into smaller ones. And whilst we're developing the proof of concept we want to make it easy to add new features. As there are multiple developers though we should all have a clear understanding of what each part of the code does.

## Pros and Cons of the Options

### N-Tier

https://learn.microsoft.com/en-us/azure/architecture/guide/architecture-styles/n-tier

* Good, because it splits the responsibilities of classes in our codebase up
* Good, because it makes it easier to test our code
* Good, because it makes dependency injection easy
* Good, because it should make fault finding easier
* Good, because it makes adding features which use common functionality quicker
* Good, because new developers looking at the code can more easily understand what they're looking at
* Bad, because it adds file bloat
* Bad, because it takes longer to add features that don't make use of common functionality
* Bad, because it requires more effort to develop features

### Monolithic

https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#what-is-a-monolithic-application

* Good, because it is very quick to add new features
* Bad, because it could have tightly coupled code, making it hard to find and fix faults
* Bad, because there may be blurred responsibilities of endpoints
* Bad, because there is a lot of opportunity for code to be repeated
* Bad, because when multiple developers are working on it they may find it hard to understand what other developers have done

### Clean

https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

* Good, because it's harder for developers to cut corners
* Good, because it segragates responsibilities making it easier to find and fix faults
* Good, because it should be easier to take specific parts of the application out
* Good, because there is a clear process for adding new features
* Bad, because it requires a lot of setup
* Bad, because it can be difficult for inexperienced developers to get to grips with
* Bad, because it adds in a lot of steps for adding new features
