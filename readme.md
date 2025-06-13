[![Build status](https://img.shields.io/appveyor/ci/alunacjones/lsl-disposables-environmentvariables.svg)](https://ci.appveyor.com/project/alunacjones/lsl-disposables-environmentvariables)
[![Coveralls branch](https://img.shields.io/coverallsCoverage/github/alunacjones/LSL.Disposables.EnvironmentVariables)](https://coveralls.io/github/alunacjones/LSL.Disposables.EnvironmentVariables)
[![NuGet](https://img.shields.io/nuget/v/LSL.Disposables.EnvironmentVariables.svg)](https://www.nuget.org/packages/LSL.Disposables.EnvironmentVariables/)

# LSL.Disposables.EnvironmentVariables

A simple library to allow for disposable environment variables. It provides a scope for a set of environment variables and ensures that the state of the environment variables is restored after the scope has been disposed.

# Quick Start

```csharp
using LSL.Disposables.EnvironmentVariables;

...

using var disposableEnvironmentVars = new DisposableEnvironmentVariables();

Environment.SetVariable("test", "value");

// test is only available in this scope
// Any added variables will be removed once the
// scope has been exited (disposableEnvironmentVars has been disposed)
```
<!-- HIDE -->
## Further Documentation

More in-depth documentation can be found [here](https://alunacjones.github.io/LSL.Disposables.EnvironmentVariables/)
<!-- END:HIDE -->