---
status: "Proposed"
date: {2025-01-03}
---

# Using our database to store user login details

## Context and Problem Statement

We need to decide how we are going to store the user profiles so that we can track roles, who's borrowing items and any information that might be necessary to provide users with a good experience.

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

[Storing user data best practices](https://stackoverflow.com/questions/6709775/methods-for-storing-login-information-in-database)

* Good, because it's simple
* Good, because we have complete control over it
* Good, because it's quick and incorporated in the app flow
* Bad, because we'll have to implement our own encryption
* Bad, because we're storing it in our database so if that breaks it might break everything
* Bad, because if the system fails then it will require specialist knowledge and we'll be responsible for it
* Bad, because we're responsible for holding the data which might be senstive

### Multi-factor
[Multi-factor in C#](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/mfa?view=aspnetcore-9.0)

We would send an email / text with a code that you then use to sign in.

* Good, because it's secure and doesn't require any additional encryption
* Good, because it's easy for the user and doesn't require them to remember a new password
* Bad, because if someone loses their email / phone then you've lost your account
* Bad, because it can feel slow and clunky for the user to switch apps
* Bad, because when you change your device it can be awkward to get it back
* Bad, because you have to send notifications which will cost money

### Custom SSO Solution
[What is SSO](https://frontegg.com/guides/single-sign-on-sso)
Make use of a custom SSO solution online

* Good, because it's quick and incorporated in the app flow
* Good, because it's very secure and doesn't require additional encryption
* Good, because it's availability is independent of our system
* Good, because it's simple to incorporate into our own projects
* Bad, because their might be an additional cost
* Bad, because if the user loses access to one system a malicious user will have access to them all
* Bad, because if it goes down there's nothing we can actively do to fix it

### Google / Facebook SSO
[Integrating with Google](https://developers.google.com/identity/sign-in/web/sign-in)
Use your google or facebook account to sign in to our apps

* Good, because it's simple to set up
* Bad, because it means we need a custom role solution
* Bad, because employees might not want to register with their real accounts

### SSO With Multi-factor

This would be the same as above but with the addition of a multi factor sign in process.

* Good, because this is even more secure
* Bad, because it's slower for the user

### More Information
