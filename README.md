# Wham Watchdog [![Deployment](https://github.com/mjamesharmon/wham-watchdog/actions/workflows/build-and-deploy.yml/badge.svg)](https://github.com/mjamesharmon/wham-watchdog/actions/workflows/build-and-deploy.yml)

## Overview

Wham Watchdog is a .NET command-line application that analyzes global pop charts and determines if Last Christmas! is #1 on the charts somewhere in the world.  The application is built using the .NET framework, offers several command-line options to customize its behavior and supports extension via XSLT.

## Table of Contents

1. [Installation](#installation)
2. [Usage](#usage)
3. [Custom Transformations](#custom-transformations)

![Last Christmas!](https://mjamesharmon.github.io/wham-watchdog/web/assets/img/last_christmas.jpeg)


## Installation

To use Wham Watchdog, follow these steps:

1. Clone the repository to your local machine:

```bash
git clone https://github.com/mjamesharmon/wham-watchdog.git
cd wham-watchdog
```
2. Build the application

```bash
dotnet build
```

3. Run the application

```
dotnet run [output_path] [command line options]
```

## Usage
Wham Watchdog runs from the command-line and performs data transformations. A Markdown and HTML format are included by default and the raw XML export of the ranking is generated by default. Below is an overview of its command-line options:

#### Command Line Options
The application supports the following command-line options:

--transform or -t: (Optional) Specifies the path to a custom XSLT file. Default is an empty string.

--output or -o: (Optional) Specifies the filename for output produced by the -t option. Default is an empty string.

--md: (Optional) Includes markdown transform. Default is false.

--html: (Optional) Includes HTML transform. Default is false.

--noxml: (Optional) Suppresses the XML transform. Default is false.

## Custom Transformations
Wham Watchdog can be extended by building a custom transformations using XSLT. You can specify your own XSLT file using the --transform option. This allows users to define and apply their unique transformations to the ranking data.

To create a custom XSLT file, follow the XSLT specification to design a transformation and save the file with a .xslt extension. Then, provide the path to your custom XSLT file using the --transform option when running the application.

