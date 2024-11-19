---
# These are optional metadata elements. Feel free to remove any of them.
status: "{proposed | rejected | accepted | deprecated | … | superseded by ADR-0123"
date: {YYYY-MM-DD when the decision was last updated}
decision-makers: {list everyone involved in the decision}
consulted: {list everyone whose opinions are sought (typically subject-matter experts); and with whom there is a two-way communication}
informed: {list everyone who is kept up-to-date on progress; and with whom there is a one-way communication}
---

# Using our database to store user login details

## Context and Problem Statement

{Describe the context and problem statement, e.g., in free form using two to three sentences or in the form of an illustrative story. You may want to articulate the problem in form of a question and add links to collaboration boards or issue management systems.}

## Decision Drivers

* Make sure individuals have the correct role
* Ensure user data is unavailable to malicious users
* Identify users throughout their use of the app

## Considered Options

* Database
* Multi-Factor
* (Single Sign-On) SSO
* SSO with Multi-Factor

## Decision Outcome

Chosen option: Database, because we'll have full control over the system. This will allow us to ensure the user data is properly managed. There will also be no additional service to have to subscribe to so there wont be unexpected costs. It will also be simple to connect the logged in user to the database as all their profile information will be readily available.

## Pros and Cons of the Options

### Database

* Good, because it's simple
* Good, because we have complete control over it
* Good, because it's quick and incorporated in the app flow
* Bad, because we'll have to implement our own encryption
* Bad, because we're storing it in our database so if that breaks it might break everything
* Bad, because if the system fails then it will require specialist knowledge and we'll be responsible for it
* Bad, because we're responsible for holding the data which might be senstive

### Multi-factor

We would send an email / text with a code that you then use to sign in.

* Good, because it's secure and doesn't require any additional encryption
* Good, because it's easy for the user and doesn't require them to remember a new password
* Bad, because if someone loses their email / phone then you've lost your account
* Bad, because it can feel slow and clunky for the user to switch apps
* Bad, because when you change your device it can be awkward to get it back
* Bad, because you have to send notifications which will cost money

### Custom SSO Solution

Make use of a custom SSO solution online

* Good, because it's quick and incorporated in the app flow
* Good, because it's very secure and doesn't require additional encryption
* Good, because it's availability is independent of our system
* Good, because it's simple to incorporate into our own projects
* Bad, because their might be an additional cost
* Bad, because if the user loses access to one system a malicious user will have access to them all
* Bad, because if it goes down there's nothing we can actively do to fix it

### Google / Facebook SSO

Use your google or facebook account to sign in to our apps

* Good, because it's simple to set up
* Bad, because it means we need a custom role solution
* Bad, because employees might not want to register with their real accounts

### SSO With Multi-factor

This would be the same as above but with the addition of a multi factor sign in process.

* Good, because this is even more secure
* Bad, because it's slower for the user

<!-- This is an optional element. Feel free to remove. -->
## More Information

{You might want to provide additional evidence/confidence for the decision outcome here and/or document the team agreement on the decision and/or define when/how this decision the decision should be realized and if/when it should be re-visited. Links to other decisions and resources might appear here as well.}
