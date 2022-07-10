# NotesApp-DomainDrivenDesign
It is a Domain Driven Design Focused sample API implementation where users can save their notes.

## Installation
First of all, it must be entered in the project folder.
```bash
$ cd NotesApp
```
And then run 
```bash
$ docker compose up
```
and than app runs. You can find detailed documentation at <a href="http://localhost:3000/swagger" target="_blank">localhost:3000/swagger</a> 
## Used Techs
- [x] PostgreSQL
- [x] .Net 6
- [x] Docker

## Used Patterns
- [x] Decarator Design Pattern (For Caching)
- [x] Specification Pattern
- [x] Generic Repository Pattern
## DDD Aproach

This application has been designed in line with Domain Driven Design Principles. In this context, there are 2 aggregate roots. These are Account and Note Aggregates, respectively. StandardUser and Admin Classes are derived from Account Abstract class. Email is the Value object of the Account Aggregate. TextNote and ImageNote Classes are derived from Note Abstract class. Tag is the Value object of the Note Class. A diagram is given in the picture below.
![DDD-Approach](https://github.com/halitdogmen/NotesApp-DomainDrivenDesign/blob/main/docs/DDD-Approach.png?raw=true)

## Layers

![Layers](https://github.com/halitdogmen/NotesApp-DomainDrivenDesign/blob/main/docs/Layer%20Diagram.png?raw=true)
