---
tags:
  - Trigger
---

# Triggers

A Trigger contains a set of [Expressions](./expressions.md) that cumulatively evaluates to a boolean value stored in a single output [Data Variable](./data-variables.md).

## Trigger Tables

Another way of thinking about Triggers is like a table, where each row in the table represents a trigger, and each cell in a row represents an [Expression](./expressions.md). All the cells must be `True` for the whole row to be `True`.

| Trigger Name | Data Variable A | Data Variable B |
| ------------------------ | ----- |------ |
| All numbers are positive | A > 0 | B > 0 |
| All numbers are negative | A < 0 | B < 0 |

If we have data variables with values `A=3` and `B=2`, our trigger table would evaluate as follows:

| Trigger Name | Data Variable A = 3| Data Variable B =2 | Trigger evaluation |
| ------------------------ | ---------------------- | ---------------------- | ------------------------- |
| All numbers are positive | :material-check: A > 0 | :material-check: B > 0 | :material-check-all: True |
| All numbers are negative | :material-close: A < 0 | :material-close: B < 0 | :material-close: False    |

The `All numbers are positive` trigger has has been triggered!

## Sparse Trigger Tables

Furthermore, not every trigger has to define a condition for every data variable, a sparsely populated Trigger Tables represents this:

| Trigger Name | Data Variable A | Data Variable B | Data Variable C | Data Variable D |
| ------------------------------- | ----- | ----- | ----- | ----- |
| All numbers are positive        | B > 0 | B > 0 | C > 0 | D > 0 |
| At least one number is positive | A > 0 |       |       |       |
| At least one number is positive |       | B > 0 |       |       |
| At least one number is positive |       |       | C > 0 |       |
| At least one number is positive |       |       |       | D > 0 |
| All numbers are negative        | A < 0 | B < 0 | C < 0 | D < 0 |

If we have data variables with values `A=3`, `B=2`, `C=-1` and `D=-6`, our trigger table would evaluate as follows:

| Trigger Name | Data Variable A | Data Variable B | Data Variable C | Data Variable D | Trigger evaluation |
| ------------------------------- | ---------------------- | ---------------------- | ---------------------- | ---------------------- | ------------------------- |
| All numbers are positive        | :material-check: B > 0 | :material-check: B > 0 | :material-close: C > 0 | :material-close: D > 0 | :material-close: False    |
| At least one number is positive | :material-check: A > 0 |                        |                        |                        | :material-check-all: True |
| At least one number is positive |                        | :material-check: B > 0 |                        |                        | :material-check-all: True |
| At least one number is positive |                        |                        | :material-close: C > 0 |                        | :material-close: False    |
| At least one number is positive |                        |                        |                        | :material-close: D > 0 | :material-close: False    |
| All numbers are negative        | :material-close: A < 0 | :material-close: B < 0 | :material-close: C < 0 | :material-close: D < 0 | :material-close: False    |

The `At least one number is positive` trigger has has been triggered!
