#!/bin/bash

echo check node version
node --version

echo check python version. You need either python or python3 to succeed
python --version
python3 --version

echo check pip version
pip3 --version

echo build documents portal
cd DocumentationPortal
mkdocs build --strict