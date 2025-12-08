# Dynamisk Feature-validering (MVP)

Detta projekt demonstrerar hur man dynamiskt validerar ett **Feature-objekt** med regler som kan ändras över tid, med hjälp av **Builder Pattern**.

---

## ❓ Koncept: Vad vi gör

Vi validerar ett **Feature-objekt** dynamiskt eftersom:

- Varje Feature har **egenskaper** (`PropertyTypes`) som kan vara obligatoriska eller valfria.
- Regler om vilka egenskaper som är giltiga lagras i en **databas** och kan ändras över tid.
- Vi vill inte hårdkoda valideringslogik — istället används **Builder Pattern** för att dynamiskt skapa validatorer baserat på reglerna.

**Varför Builder Pattern?**

- Separar **hämtning av regler** från **exekvering av validering**.
- Gör det enkelt att **lägga till nya validatorer** utan att ändra huvudflödet.
- Fungerar bra när regler kan ändras per `featureType` eller egenskap.

---

## 🌊 Valideringsflöde (Hög nivå)

1. **Feature skickas in** → JSON-objektet anländer.
2. **Regelhämtare** → Hämtar valideringsregler från databasen för den aktuella featuretypen.
3. **Validation Builder** → Läser regler och skapar dynamiskt en **pipeline av validatorer**.
4. **Validation Pipeline** → Kör alla validatorer i sekvens.
5. **Validation Resultat** → Returnerar pass/fail och felmeddelanden.


## ⚙️ MVP Implementation (C#)

- **Modeller:** `Feature` och `PropertyType`
- **Regler:** `RuleDefinition`-objekt
- **Validatorer:** `IValidator`-interface + konkreta validatorer (`RequiredValidator`, `AllowedValuesValidator`, `DateRangeValidator` ect ect...)
- **Builder:** Läser regler och skapar en `ValidationPipeline`
- **Pipeline:** Kör alla validatorer och samlar felmeddelanden

---

![img_1.png](testbuilder/img_1.png)
![img.png](testbuilder/img.png)
