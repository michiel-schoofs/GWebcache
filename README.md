# GWebcache
![NuGet Downloads](https://img.shields.io/nuget/dt/GnutellaSharp.GWebcache) ![GitHub Release](https://img.shields.io/github/v/release/GnutellaSharp/GWebcache?include_prereleases)
![Build Succeeding](https://github.com/gnutellasharp/GWebcache/actions/workflows/build-testing.yml/badge.svg)

C# library and nuget package to interact with a Gnutella Webcache

## Documentation

You will find the documentation trough this [link](https://gnutellasharp.github.io/GWebcache/).
Documentation is being autogenerated based on XML comments in the code.
These are converted to html trough DoxyGen and deployed to github pages.
As a collaborator we ask that you provide [XML comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags) when writing new classes or methods.

## Examples
You can find example code using the following [link](Examples.md)

## Supported Caches

There's a lot of different implementations of the GWebCache system out there.
The following implementation we mocked and tested for so normally all functionality should work from these caches.
We do follow the specification so other vendors should also work if they comply.

| Vendor  | Version number |
| ------------- | ------------- |
| Bazooka | 0.3.6b |
| DKAC/Enticing-Enumon  | /  |
| Beacon Cache II | 0.8.0.1 |
| GhostWhiteCrab | 0.9.7 |
| Skulls | 0.3.6 |