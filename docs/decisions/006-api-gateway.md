---
# These are optional metadata elements. Feel free to remove any of them.
status: "proposed3"
date: 2024-12-11
---

# Using Yarp for the proof of concept API Gateway

## Context and Problem Statement

Currently we use multiple services to handle API calls from our frontend. Eventually we will want to connect to an API gateway hosted in the cloud. However before then we should create a service that acts as our gateway so that transferring the code to being cloud hosted is smoother.

## Considered Options

* Yarp
* Ocelot

## Decision Outcome

Chosen option: "Yarp", because it's microsoft first party software so well documented, and easy to setup.

## Pros and Cons of the Options

### Yarp

* Good, because it's microsoft so should be well supported
* Good, because it's well documented
* Good, because it's easy to setup
* Good, because it's based on ASP.NET which is what we're using
* Neutral, because it requires installing external packages
* Bad, because it requires slightly more configuration that ocelot

### Ocelot

* Good, because it's slightly easier to setup compared to Yarp
* Bad, because it's not supported directly by microsoft

<!-- This is an optional element. Feel free to remove. -->
## More Information

References
https://dev.to/arashyazdani/a-deep-dive-into-yarp-and-ocelot-4dbo
