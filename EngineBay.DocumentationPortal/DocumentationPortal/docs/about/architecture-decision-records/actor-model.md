---
tags:
  - Architecture Decision Record
---

# Actor model

## Date

3 January 2023

## What is this about?

This ADR captures some of the thinking around basing a rules engine on the actor model.

## What's the gist of an actor model based rules engine?

If we think about a rules engine being a simple set of *inputs* being *processed* to produce and *outputs*; in the actor model, each *input*, *process*, and *output* is an independent actor. Each actor sends messages to other actors to do things.

For example, and *input* informing a *process* of a change in it's value, or a *process* updating an *output* with the result of the *process*.

Many cohesive actors could model systems, I.e. business rules, at a tantalizingly extreme level of complexity and scale.

## Should we even build another rules engine?

Uncle bob's article on rules engines was read (and re-read) to appropriately demotivate us on the value of a rules engine. The dream of non technical users defining business rules independently in a low code / no code fashion that are production ready is lovely. But it's just a dream. The real world is that rules engines take a lot of hard work and discipline across the business (technical and non-technical) to get it right.

The success of rule engines in the business context is more about the people, teams and collaboration with subject matter experts. It's about the user experience and workflow. It's about integration with the rest of the business.

In the right context, a crude "rules engine" comprised of some hard coded if statements running in a loop is more valuable to business thn the most elegant, performant and flexible rules engine possibly conceivable to mankind.

So, I'm short: no we should not build another rules engine.

But...

Gosh darn it!… doesn't the idea of an actor model based rules engine just sound interesting?

Let's just build it anyway to see if we can.

## Considerations

Spreadsheets were a source of inspiration. Spreadsheets are kind of like an actor model; each cell interacts with other cells in the spreadsheet to perform calculations or hold values.

Love them or hate them, we believe that businesses get immense value out of simple spread sheet models. Most of the time, a spreadsheet it good enough for most business activities (especially to start with). The can store and track data, calculate things, and are relatively intuitive.

Spread sheets can also scale in complexity, far beyond what us mere humans can actually cope with. Each of us will have dealt with some legacy super spreadsheet at some point in time. (You know, the one in that shared folder that you should never edit because no-one knows how it works, but the entire business depends on?)

How many times have software engineers had to reverse engineer a spreadsheet and systematize it so that the business can have a "system" for their business activities rather than some spreadsheet. The very process of systematization changes the behavior of the model, normally for the better, but frustrates business because it's no longer the same. All they really wanted was to take their spreadsheet and run it on a web server somewhere (a la Docker)

So, we're not trying to replace spreadsheets, but rather, we consider that there's a need for alternative computation models and increasingly complex levels.

## What opportunities does this create?

* The actor model conceptually plays well with the Rete Algorithm, a classical design rules engine
* The actor model lends itself to both stateless and stateful paradigms. Digital twins are a possibility.
* The actor model lends itself to distributed computation.

## What risks does this create

* The world might not need or want more complicated ways of doing business rules.
* The costs and overheads of each autonomous actor and their messaging may incur performance hits that eventually undermine the overall value proposition.
* The actor model lends itself more to asynchronous business workflows mare than synchronous and latency critical ones.
* The actor model depends heavily on actor state and state management. OOP design patterns and principals are likely to be important.
