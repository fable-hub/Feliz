---
sidebar_position: 1
---

# Installation

To install `Feliz.Recharts` into your project, you need to install the nuget package into your F# project

```bash
# nuget
dotnet add package Feliz.Recharts
# paket
paket add Feliz.Recharts --project ./project/path
```

Then you need to install the corresponding npm dependencies. In case of Feliz.Recharts, it is `recharts`

```bash
npm install recharts@2.0.9
```

### Use Femto

If you happen to use [Femto](https://github.com/Zaid-Ajaj/Femto), then it can install everything for you in one go

```bash
cd ./project
femto install Feliz.Recharts
```

Here, the nuget package will be installed using the package manager that the project is using (detected by Femto) and then the required npm packages will be resolved
