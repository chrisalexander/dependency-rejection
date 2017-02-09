# Dependency rejection

A brown bag / workshop based on Mark Seemann's excellent NDC London presentation / blog series.

## Resources

* [Functional](https://media.giphy.com/media/26xBQ9WMsIatCws5q/giphy.gif)
* [Scala comic](http://blog.ploeh.dk/content/binary/dependency-injection-in-scala-comic.jpg)
* [Mark's original blog series](http://blog.ploeh.dk/2017/01/27/from-dependency-injection-to-dependency-rejection/)
* [Ports and Adapters diagram](http://blog.ploeh.dk/content/binary/ports-and-adapters-conceptual-diagram.png)

## Agenda

- A note about what it means to be "functional" - will later drive by Haskell
- What are we trying to do? DI in F#
- Example of C# constructor injection
- Example of F# partial application
- Decompiling the F# partial application to C#
- Functional purity
  - Haskell IO type
  - LOL F#
- Function composition
  - Reject composition
  - Pure and impure sandwich
- Brief mention of Ports and Adapters