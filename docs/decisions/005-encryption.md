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

Chosen option: Hashed Password because it can be implemented effiectly to provide a deeper level of security for the users.


### Consequences

* Good, because it can resist brute force and reduces the size in the database
* Bad, because it can't handle large amounts of data and collision risks with same hash value


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

References
[Hashed vs 1 way encryption vs symmetric] (https://www.sealpath.com/blog/types-of-encryption-guide/)

