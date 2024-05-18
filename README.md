# BemIt

A BEM(Block Element Modifier) classes generator.

> [BEM](https://getbem.com/) — is a methodology that helps you to create reusable components and code sharing in front‑end development.

## Getting Started

### Prerequisites

NET 6.0 or later

### Installing

```shell
dotnet add package BemIt
```

### Usage

```csharp
using BemIt;

var card = new Block("card"); // card
var outlinedCard = card.Modifier("outlined"); // card--outlined
var cardTitle = card.Element("title"); // card__title
var largeCardTitle = cardTitle.Modifier("large"); // card__title--large
```

```csharp
using BemIt;

enum Density
{
    Dense,
    Comfortable,
    Compact,
}

var outlined = true;
var isDisabled = true;
var density = Density.Dense;

var cardModifierBuilder = new Block("card")
    .CreateModifierBuilder()
    .Add(outlined)
    .Add("disabled", isDisabled)
    .Add(density)
    .AddClass("theme--light");

var cardClasses = cardModifierBuilder.Build();
// output: card card--outlined card--disabled card--density-dense theme--light
```
