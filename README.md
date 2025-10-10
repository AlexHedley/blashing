# ![bowtie (blazor)](docs/images/bowtie_blazor_logo.png "bowtie (blazor)") Blashing

> Build a beautiful dashboard

[![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Blazor](https://img.shields.io/badge/blazor-%235C2D91.svg?style=for-the-badge&logo=blazor&logoColor=white)](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
[![License: MIT](https://img.shields.io/badge/License-MIT-lightgrey.svg?style=for-the-badge)](LICENSE) <!-- https://opensource.org/licenses/MIT -->
[![Dependabot](https://img.shields.io/badge/dependabot-025E8C?style=for-the-badge&logo=dependabot&logoColor=white)](https://github.com/AlexHedley/blashing/security/dependabot)
[![Dependency-Check](https://img.shields.io/badge/DependencyCheck-f78d0a.svg?style=for-the-badge&logo=dependencycheck&logoColor=white)](https://owasp.org/www-project-dependency-check/)

[![🔨 Build / 🧪 Test (with 📊 Reports)](https://github.com/AlexHedley/blashing/actions/workflows/build-test.yml/badge.svg)](https://github.com/AlexHedley/blashing/actions/workflows/build-test.yml)
![Badge](https://gist.githubusercontent.com/AlexHedley/867fcfe2ac7154c6b610c8189adac06c/raw/blashing_core_tests.md_badge.svg "Badge")
[![Deploy to GitHub Pages](https://github.com/AlexHedley/blashing/actions/workflows/deploy-site.yml/badge.svg)](https://github.com/AlexHedley/blashing/actions/workflows/deploy-site.yml) [![pages-build-deployment](https://github.com/AlexHedley/blashing/actions/workflows/pages/pages-build-deployment/badge.svg)](https://github.com/AlexHedley/blashing/actions/workflows/pages/pages-build-deployment)
[![Dependency Check](https://github.com/AlexHedley/blashing/actions/workflows/depcheck.yml/badge.svg)](https://github.com/AlexHedley/blashing/actions/workflows/depcheck.yml)
[![Dependabot Updates](https://github.com/AlexHedley/blashing/actions/workflows/dependabot/dependabot-updates/badge.svg)](https://github.com/AlexHedley/blashing/actions/workflows/dependabot/dependabot-updates)

> A port/rewrite of Dashing / Smashing in Blazor

_Inspired by [Dashing](https://github.com/Shopify/dashing) / [Smashing](https://github.com/Smashing/smashing)_

## Site

- [https://alexhedley.github.io/blashing/](https://alexhedley.github.io/blashing/)

## Todo

<!-- ![Progress](docs/images/progress/progress.png "Progress") -->
![Demo](docs/images/progress/demo.png "Demo")

Add widgets for:

- clock (#2)
- comments (#3)
- graph (#4) _WIP_
- iframe (#5)
- image (#6)
- list (#7)
- meter (#8) _WIP_
- number (#9)
- text (#1)

Additional Widgets

- Server Status Squares (#214)
- Circle CI Build Status (#215)

## Tests

`cd src`

`dotnet test --collect:"XPlat Code Coverage"`

## Reports

![Badge](https://gist.githubusercontent.com/AlexHedley/867fcfe2ac7154c6b610c8189adac06c/raw/blashing_core_tests.md_badge.svg "Badge")

- [gist](https://gist.github.com/AlexHedley/867fcfe2ac7154c6b610c8189adac06c)

Dependency Check Report

- [dependency-check-report](https://alexhedley.com/blashing/reports/dependency-check-report.html)

## src

- [src](src/)
  - [Stories](src/Blashing.Stories)
    - [Blazing Story](https://github.com/jsakamoto/BlazingStory)

`Core` holds the original Widgets, `Widgets` holds any additional ones ported from the community.

`Stories` is using Blazing Story to show the components.

`Client` / `Server` and `Shared` are examples of how to use these components in a Blazor Application. `Shared` allows you to build a page once, for use in any.

| Project                                      | Type                                | Info  |
| -------------------------------------------- | ----------------------------------- | ----- |
| Blashing.Core                                | Microsoft.NET.Sdk.Razor             |       |
| Blashing.Core.Tests                          | Microsoft.NET.Sdk                   | xunit |
| Blashing.Widgets                             | Microsoft.NET.Sdk.Razor             |       |
| Blashing.Widgets.Tests                       | Microsoft.NET.Sdk                   | xunit |
|                                              |                                     |       |
| Blashing.Stories                             | Microsoft.NET.Sdk.BlazorWebAssembly |       |
|                                              |                                     |       |
| Blashing.Client                              | Microsoft.NET.Sdk.BlazorWebAssembly |       |
| Blashing.Server                              | Microsoft.NET.Sdk.Web               |       |
| Blashing.Shared                              | Microsoft.NET.Sdk.Razor             |       |

## Sample

Ran the example [smashing](https://github.com/Smashing/smashing) locally and took a copy of the served webpage for comparison.

- [sample](index.html)

![Original Screenshot](docs/images/progress/original_screenshot.png "Original Screenshot")

## Docs

- [docs](docs/README.md)
