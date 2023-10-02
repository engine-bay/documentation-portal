# Data Protection

## Overview

The [EngineBay.DataProtection](https://github.com/engine-bay/data-protection) provides a mechanism for encrypting security-sensitive data at rest whilst stored in the database.

This module is based on the [ASP.NET Core Data Protection APIs](https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/introduction?view=aspnetcore-7.0).

Encryption keys are stored separately from encrypted data, with multiple key store providers. Keys are automatically rotated on a configurable regular basis.
See the [Data Protection Configuration](../configuration//environment-variables.md#data-protection) for more details.

!!! danger

    Whilst this module provides easy implementations of encryption at rest. It cannot backup your keystore. If you lose the keys, or they become corrupted, you may lose encrypted data.

    We highly recommend you use a production ready keystore with a secure backup strategy.

    Practice your disaster recovery process.
