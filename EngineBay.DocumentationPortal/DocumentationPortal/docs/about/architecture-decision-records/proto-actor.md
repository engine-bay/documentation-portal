---
tags:
  - Architecture Decision Record
---

# Proto.actor

## Date

4 January 2023

## What is this about?

This ADR captures some of the thinking around basing this project on the actors model, implemented with [proto.actor](https://proto.actor).

## What characteristics did we value at the time?

* Message interchange between actors needs to be fast
* Each actor should be in its own process/thread so that we can scale to really large models.

## Considerations

[Akka.net](https://getakka.net) was considered, and whilst it was mature, it was also quite opinionated, with a complex framework for actors. Initial attempts at a prototype stalled because of 'barrier to entry' of the framework

A prototype of an actor model based engine was built in node js, with [Comedy](https://github.com/untu/comedy) as the underlying actor model framework. Whilst we were able to get a flow of logical expressions evaluating, the cost of message serialization and startup overheads of web workers were apparent with even small models. Past experience with JavaScript expression evaluation, whilst amazingly flexible, was not so great from a performance perspective.

Proto.actor on golang was considered. Golang has some extremely fast expression evaluation libraries, but the framework was pretty immature, documentation spotty, and changing all the time. Unfamiliarity with golang at the time was a bit of a deterrent, however, the appeal of grpc message interchange and "seamless" scaling of a actors across clusters was too much to resist.

So, a prototype of proto.actor on dot net was built. It took a while to get a working flow of logical expressions to be evaluated. There was a lot of inferring how the framework worked from source code and commit reviews, and some nasty memory leaks to figure out. However, eventually a satisfactorily stable and encouragingly performant prototype was producing results.

## What did we decide on?

Since proto.actor is a spiritual successor to Akka.net, used grpc for message communication between actors, and had a much simpler framework. It was selected as the underlying framework for actor control.

## What opportunities does this create?

* Proto.actor has both a golang and .net runtime. There's are in theory interoperable through the strict protobuf message formats. If needed, performance optimized Astor's could run in a golang stack, whilst other parts in the .net stack. This gives us access to package libraries from both ecosystems if we need it one day.
* We learnt a lot about the actor model through the various failed prototypes, which in turn, informed subsequent architectural decisions.

## What risks did this introduce?

* With an unstable and immature library at the core of the architecture, we are in for a rough ride as it evolves.
