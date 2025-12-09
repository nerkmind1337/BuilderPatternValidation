![Image](https://static.wikia.nocookie.net/finalfantasy/images/1/15/Weathered_Cross-pein_Hammer_from_Final_Fantasy_XIV_icon.png/revision/latest/smart/width/250/height/250?cb=20201106021505)


# Dynamic Feature Validation (MVP)

This project demonstrates how to **dynamically validate** a “Feature” object using rules that can change over time — powered by the **Builder Pattern**.

---

## 💡 What this is

Every **Feature** has a bunch of **properties** (called “property types”).  
Some are required. Some are optional. Some may only be valid under certain conditions.

The rules that decide what’s valid are stored in a **database** and can change at any moment.

Instead of hardcoding validation logic, we build validators dynamically, based on whatever rules currently exist.

### Why the Builder Pattern?

- It separates **rule fetching** from **rule execution**.
- It becomes easy to **add new validator types** without touching the main logic.
- It adapts smoothly when different feature types need different rules.

---

## 🔄 High-Level Validation Flow

1. A **Feature** is submitted (usually as JSON).  
2. A **Rule Fetcher** loads the validation rules for that feature type from the DB.  
3. A **Validation Builder** reads those rules and dynamically assembles a **pipeline** of validators.  
4. The **Validation Pipeline** runs all validators in sequence.  
5. A **Validation Result** is returned (pass/fail + error messages).

---

## 🧰 MVP Implementation (C#)

**Models**
- `Feature`
- `PropertyType`

**Rules**
- Stored as `RuleDefinition` objects.

**Validators**
- Interface: `IValidator`
- Example concrete validators:
  - `RequiredValidator`
  - `AllowedValuesValidator`
  - `DateRangeValidator`

**Builder**
- Reads DB rules
- Creates a `ValidationPipeline` with the proper validators

**Pipeline**
- Runs validators in order
- Collects all error messages
---
