---
tags:
  - Architecture Decision Record
---

# Expression Engine

## Date

3 January 2023

## What is this about?

For the engine we needed and expression parser and evaluator. It allows you to compute the value of string expressions such as `sqrt(a^2 + b^2)` at runtime with data driven parameters.

## What characteristics did we value at the time?

We cared about the following characteristics most when choosing an expression parser for the engine:

* Extensibility - we need to be able to easily extend the expression parser with custom functions.
* Intuitiveness - it should be easy for a layman to write the expressions, alignment with common syntax (like Excel) would be a benefit.
* Should have all the common logical and mathematical operators out the box
* Must be able to evaluate a ternary operator (i.e. perform an if statement)
* Fast - we're going to be evaluating a lot of these expressions, it needs to be as fast as possible.

## Considerations

A number of expression parsing libraries were considered initially, of which it was narrowed down to a few candidates

* [Flee](https://github.com/mparlak/Flee)
* [NCalc](https://github.com/ncalc/ncalc)
* [Jint](https://github.com/sebastienros/jint)
* [mXparser](https://mathparser.org/)
* [Eval Expression](https://eval-expression.net/)
* [Moonsharp](https://github.com/moonsharp-devs/moonsharp/)

## What did we decide on?

Starting with [Flee](https://github.com/mparlak/Flee) to keep it simple to start with. Whilst not particularly popular, it's feature set matched the criteria the best for the proof of concept phase.

We're also going to create a layer of abstraction over the parser so that we can swap it out, or extend it, in the future.

## What opportunities does this create?

* The expression parsers can be extended with [Jint](https://github.com/sebastienros/jint) or [Moonsharp](https://github.com/moonsharp-devs/moonsharp/) for more features if needed in the future, such as JS or LUA functions.

## What risks did this introduce?

* Flee isn't that popular, we might end up forking it and maintaining it internally
