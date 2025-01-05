---
status: "Accepted"
date: {2025-01-03}
---

# Relational or Non-relational database

## Context and Problem Statement

The architecture of our system needs to be able to account for a considerable increase in users year on year. The system is also made up of multiple parts so we should be prepared for further feature requirements as there become more users.

## Considered Options

- SQL database
- No SQL database

## Decision Outcome

Chosen option: SQL database, because we know the structure of the data. We are also more familiar with using SQL.

## Pros and Cons of the Options

### SQL database


* Good, because we have more experience using it
* Good, because it allows us to organise the data
* Good, because we know the strucutre of our data wont change frequently
* Good, because we may want to aggregate differernt types of data 
* Bad, because it can be slow if there are lots of joins in data
* Bad, because the initial setup will be longer

### No-SQL database

* Good, because it's flexible so change is easy
* Good, because it's faster
* Bad, because it will send through all the data
* Bad, because data may not be consistent


<!-- This is an optional element. Feel free to remove. -->
## More Information

[SQL vs NoSQL](https://www.coursera.org/articles/nosql-vs-sql)