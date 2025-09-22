---
title: Feliz Template
sidebar_position: 2
---

:::info
This site is still WIP for this release!
:::


# Project Template [![Nuget](https://img.shields.io/nuget/v/Feliz.Template.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.Template)

Feliz includes a template that scaffolds a full-fledged frontend application in one go. This is the easiest way to get started with Feliz and Elmish. The template also includes a test project that can run live in the browser or using node.js and mocha.

### Install the template

Install the template into your dotnet project templates as follows
```bash
dotnet new -i Feliz.Template
```
Now you should be able to create a new Feliz project as follows:
```bash
dotnet new feliz -n AwesomeApp
```
Now you are good to go. This will scaffold the application inside the newly created `AwesomeApp` directory.

### Update the template

Remember to update the template every once in a while especially before you scaffold a new project so that you get the latest updates from the template. Updating the template is a matter of uninstalling then re-installing it:
```bash
dotnet new -u Feliz.Template
dotnet new -i Feliz.Template
```

### Run the app

After you have installed the template, you can run the follwing command to install dependencies:
```bash
npm install
```
Next, run this command to start the webpack-dev-server and see your app running at http://localhost:8080:
```bash
npm run start
npm start # for short
```
View the `package.json` file and the `scripts` section to see other available scripts to run.


### Troubleshooting: potential Firefox/Chrome console errors

The template assumes that you have installed Redux DevTools in the browser you are developing with, either Chrome or Firefox. If you haven't installed either, you get a number of console error logs where the application is trying to connect to these tools during development so you have to install these dev tools to get rid of the otherwise harmless but annoying logs:

- [Redux DevTools Extension](https://chrome.google.com/webstore/detail/redux-devtools/lmhkpmbekcpmknklioeibfkpmmfibljd) for Chrome
- [Redux DevTools Extension](https://addons.mozilla.org/en-US/firefox/addon/reduxdevtools/) for Firefox
