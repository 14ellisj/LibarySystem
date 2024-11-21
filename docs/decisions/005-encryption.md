---
# These are optional metadata elements. Feel free to remove any of them.
status: proposed
date: 21/11/24
decision-makers: Henry Barker, Jake Ellis, Joe Denton
consulted: N/A
informed: {list everyone who is kept up-to-date on progress; and with whom there is a one-way communication}
---

# How to secure the users' passwords

## Context and Problem Statement

We need a way to keep the passwords secure in the database

<!-- This is an optional element. Feel free to remove. -->
## Decision Drivers

* {decision driver 1, e.g., a force, facing concern, …}
* {decision driver 2, e.g., a force, facing concern, …}
* … <!-- numbers of drivers can vary -->

## Considered Options

* Hashed password
* 1 way encryption
* Symmetric key

## Decision Outcome

Chosen option: "{title of option 1}", because {justification. e.g., only option, which meets k.o. criterion decision driver | which resolves force {force} | … | comes out best (see below)}.

<!-- This is an optional element. Feel free to remove. -->
### Consequences

* Good, because {positive consequence, e.g., improvement of one or more desired qualities, …}
* Bad, because {negative consequence, e.g., compromising one or more desired qualities, …}
* … <!-- numbers of consequences can vary -->

<!-- This is an optional element. Feel free to remove. -->
### Confirmation

{Describe how the implementation of/compliance with the ADR can/will be confirmed. Is the chosen design and its implementation in line with the decision? E.g., a design/code review or a test with a library such as ArchUnit can help validate this. Note that although we classify this element as optional, it is included in many ADRs.}

<!-- This is an optional element. Feel free to remove. -->
## Pros and Cons of the Options

### Hashed password 

Scrambling a password with it's own contents and adding a special key 

* Good, because it's simple to implement
* Bad, because it can't handle very large amounts data
* Bad, because it has been known not to be very secure

### 1 Way encryption

Scrambling it with a key to unscramble it

* Good, because it is more secure than hashing
* Bad, because if you don't have the key you can't unscramble the password

### Symmetric Key

Scrambling it with a key to unscramble it

* Good, because it is secure
* Good, because it is fast
* Bad, because the key might need to be brought to different places and therefore makes the key less secure

{You might want to provide additional evidence/confidence for the decision outcome here and/or document the team agreement on the decision and/or define when/how this decision the decision should be realized and if/when it should be re-visited. Links to other decisions and resources might appear here as well.}
