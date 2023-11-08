# EngineBay.DocumentationPortal

[![NuGet version](https://badge.fury.io/nu/EngineBay.DocumentationPortal.svg)](https://badge.fury.io/nu/EngineBay.DocumentationPortal)
[![Maintainability](https://api.codeclimate.com/v1/badges/1b17960d6d125f22eff5/maintainability)](https://codeclimate.com/github/engine-bay/documentation-portal/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/1b17960d6d125f22eff5/test_coverage)](https://codeclimate.com/github/engine-bay/documentation-portal/test_coverage)

DocumentationPortal module for EngineBay published to [EngineBay.DocumentationPortal](https://www.nuget.org/packages/EngineBay.DocumentationPortal/) on NuGet.

## About

This is the documentation repository for Engine Bay, it uses [mkdocs](https://github.com/mkdocs/mkdocs) to generate a static site from markdown files. Documentation can be added as markdown files in the [docs](./EngineBay.DocumentationPortal/DocumentationPortal/docs/) folder.

## Prerequisites

Please ensure that you have the following installed

- [Node](https://nodejs.org/)
    ```bash
    node --version
    ```
- [Python](https://www.python.org/)
    ```bash
    python --version
    python3 --version
    ```
- [Pip](https://pip.pypa.io/en/stable/installation/). Pip should be installed with Python, check using the following command
    ```bash
    pip3 --version
    ```

## Usage

The `mkdocs build` command will be executed when we build this [project](./EngineBay.DocumentationPortal/EngineBay.DocumentationPortal.csproj) using `dotnet build`.

In the development environment mkdocs will build with the `--dirty` flag, this will give the fastest build times but could have issues with links etc. To fix these issues either build using `mkdocs build --strict` or by using the [build script](./EngineBay.DocumentationPortal/generate-docs.sh).

In the pipelines we wil do the longer full build.

## Deploying the static site

TBC - This will be hosted as github pages.