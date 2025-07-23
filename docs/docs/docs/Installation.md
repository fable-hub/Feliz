---
title: Installation
sidebar_position: 1
---

# Feliz - Installation

To install Feliz into your project, you need to install the nuget package into your F# project
```bash
# nuget
dotnet add package Feliz
# paket
paket add Feliz --project ./project/path
```
Then you need to install the corresponding npm dependencies. In case of Feliz, these are `react` and `react-dom`
```bash
npm install react@17.0.1 react-dom@17.0.1
```

### Use Femto

If you happen to use [Femto](https://github.com/Zaid-Ajaj/Femto), then it can install everything for you in one go
```bash
cd ./project
femto install Feliz
```
Here, the nuget package will be installed using the package manager that the project is using (detected by Femto) and then the required npm packages will be resolved
