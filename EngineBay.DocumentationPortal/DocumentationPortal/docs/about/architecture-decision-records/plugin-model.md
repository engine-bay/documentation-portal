---
tags:
  - Architecture Decision Record
---

# Plugin model

## Date

17 March 2023

## What is this about?

With the decision to take the project down the route of a [Sponsorware](https://github.com/sponsorware/docs) model, to balance open sourcing desires with monetization and support needs, the code base needs to be re-structured to be a blend of open and closed source modules.

Sponsorware is a release strategy for open-source software that enables developers to be compensated for their open-source work with fewer downsides than traditional open-source funding models.

## What characteristics did we value at the time?

* We cared deeply about keeping the project code base in a maintainable structure, regardless of whether it was open or closed source. We wanted to avoid human error in having to copy-paste content across repositories, or introduce regressions by managing multiple code bases.
* We wanted to avoid the complexity of sub-repos.
* We wanted to keep the project easy to host, both the community distributions and the sponsored distributions with enhanced feature sets.
* We wanted to be able to carefully manage change, knowing when things break, and when it's safe to upgrade.

## Considerations

Licensing of each module needs to be carefully considered. Whilst a copyleft or weak-copyleft is desireable, it would prevent the sponsorware model, so a more permissive license is required for open-source modules, such as [MIT](https://fossa.com/blog/open-source-licenses-101-mit-license/).

## What did we decide on?

With the vision of a more plugin and pluggable architecture in mind, we decided to start refactoring sensible parts of the codebase into independent [NuGet](https://www.nuget.org/) packages.

To try keep modules as independent but meaningful "vertical slices" of functionality that can be composed into a greater system, we chose to follow some of the these [project structure ideas](https://timdeschryver.dev/blog/maybe-its-time-to-rethink-our-project-structure-with-dot-net-6#a-domain-driven-api) along with [.Net minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-7.0).

## What opportunities does this create?

* The plugin approach should open up the code base to the community, allowing contribution to open-sourced modules, as well as providing future community extension points to the core.
* NuGet covers the core need for .Net packages at the moment, but this can easily be extended to include NPM or other package managers as the project's functionality grows.

## What risks did this introduce?

* Decomposing the codebase into a more modular and pluggable architecture is going to introduce some extra work from time-to-time to keep things decoupled. This may slow down new feature work or big changes at times.
* There will probably be contention sometime down the line where certain features may fall into a grey area on being open/closed source.
