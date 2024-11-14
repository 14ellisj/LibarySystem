---
# These are optional metadata elements. Feel free to remove any of them.
status: accepted
date: 11/11/2024
decision-makers: Henry Barker, Jake Ellis, Joe Denton
informed: {list everyone who is kept up-to-date on progress; and with whom there is a one-way communication}
---

# Relational or Non-relational database

## Context and Problem Statement

The architecture of our system needs to be able to account for a considerable increase in users year on year. The system is also made up of multiple parts so we should be prepared for further feature requirements as there become more users.

<!-- This is an optional element. Feel free to remove. -->
## Decision Drivers

* {decision driver 1, e.g., a force, facing concern, …}
* {decision driver 2, e.g., a force, facing concern, …}
* … <!-- numbers of drivers can vary -->

## Considered Options

- SQL database
- JSON database

## Decision Outcome

Chosen option: SQL database, because the library has many interconnecting tables that all reference each other to structure their data.

<!-- This is an optional element. Feel free to remove. -->
### Consequences

* Good, because this allows us to have a very interconnected database
* Bad, because {negative consequence, e.g., compromising one or more desired qualities, …}
* … <!-- numbers of consequences can vary -->

<!-- This is an optional element. Feel free to remove. -->
### Confirmation

{Describe how the implementation of/compliance with the ADR can/will be confirmed. Is the chosen design and its implementation in line with the decision? E.g., a design/code review or a test with a library such as ArchUnit can help validate this. Note that although we classify this element as optional, it is included in many ADRs.}

<!-- This is an optional element. Feel free to remove. -->
## Pros and Cons of the Options

### {title of option 1}

<!-- This is an optional element. Feel free to remove. -->
{example | description | pointer to more information | …}

* Good, because {argument a}
* Good, because {argument b}
<!-- use "neutral" if the given argument weights neither for good nor bad -->
* Neutral, because {argument c}
* Bad, because {argument d}
* … <!-- numbers of pros and cons can vary -->

### {title of other option}

{example | description | pointer to more information | …}

* Good, because {argument a}
* Good, because {argument b}
* Neutral, because {argument c}
* Bad, because {argument d}
* …

<!-- This is an optional element. Feel free to remove. -->
## More Information

{You might want to provide additional evidence/confidence for the decision outcome here and/or document the team agreement on the decision and/or define when/how this decision the decision should be realized and if/when it should be re-visited. Links to other decisions and resources might appear here as well.}
