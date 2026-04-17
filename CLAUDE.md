# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build
dotnet build

# Run all tests
dotnet test

# Run a single test class
dotnet test --filter "FullyQualifiedName~TCKTests"

# Run a single test method
dotnet test --filter "FullyQualifiedName~EvaluationSimpleUnaryTestsBaseTests.SomeMethod"

# Run with coverage
dotnet test /p:CollectCoverage=true
```

## Architecture

RulesDoer is a DMN 1.2 rules engine. The execution flow is:

1. **Persistence** (`Repo/`) — `IDMNPersistence` stores raw DMN XML strings keyed by name + version. `DefaultDMNPersistence` is an in-memory singleton (thread-safe via `ConcurrentDictionary`). Implement this interface to add database/file-backed storage.

2. **Serialization** (`Serialization/DMNTransformer.cs`) — Deserializes DMN XML into the `TDefinitions` object graph via `XmlSerializer`. The `Transformer/v1_2/` folder contains all the C# classes auto-generated from `DMN12.xsd`.

3. **Repository** (`Repo/DMNRepository.cs`) — Orchestrates persistence + deserialization. `FindDefinitions` reads raw XML and returns a `TDefinitions`.

4. **Runtime** (`Runtime/`) — `DMNDoer` is the main entry point. `BuildContext` populates a `VariableContext` from a definition (decisions, BKMs, input data, item definitions). `EvaluateDecisions` runs all or a named decision against caller-supplied inputs.

5. **FEEL evaluation** (`Expressions/FEEL/`) — ANTLR4 grammar (`FEELLexer.g4` + `FEELRule.g4`) is compiled into C# during build via `Antlr4BuildTasks`. The committed `.cs` files (`FEELLexer.cs`, `FEELRule.cs`, etc.) are excluded from compilation — they are regenerated into `obj/` on every build. `Evaluation.cs` is the entry point; it builds an ANTLR parse tree and walks it with one of the listener AST classes (`ExpressionBaseAst`, `SimpleUnaryTestsBaseAst`, etc.).

### Key types

- **`Variable`** (`Runtime/Context/Variable.cs`) — Union type representing any FEEL value. Holds typed fields (`NumericVal`, `StringVal`, `BoolVal`, `DateTimeVal`, etc.) discriminated by `DataTypeEnum`. Has implicit conversions to/from .NET primitives and implements `IComparable<Variable>`.
- **`VariableContext`** (`Runtime/Context/VariableContext.cs`) — Execution context for a single evaluation run. Contains input values (`InputNameDict`), computed globals (`GlobalDict`), and metadata maps for decisions, BKMs, input data, item definitions, and decision services.
- **`DataTypeEnum`** (`Types/DataTypeEnum.cs`) — Discriminator for `Variable`: `Decimal`, `String`, `Boolean`, `Date`, `DateTime`, `Time`, `DayTimeDuration`, `YearMonthDuration`, `List`, `Context`, `Function`, `Tuple`, `DecisionTableResult`, `Null`.

### ANTLR grammar regeneration

The grammars are regenerated automatically during `dotnet build` via `Antlr4BuildTasks`. To regenerate manually (e.g., to inspect output):

```bash
java -jar /tmp/antlr-4.13.1-complete.jar -Dlanguage=CSharp \
  -package RulesDoer.Core.Expressions.FEEL -listener -no-visitor \
  src/RulesDoer.Core/Expressions/FEEL/FEELLexer.g4 \
  src/RulesDoer.Core/Expressions/FEEL/FEELRule.g4
```

The ANTLR jar version must match `Antlr4.Runtime.Standard` (currently 4.13.1).

### Tests

Tests use xUnit with a shared `DMNFixture` (implements `IClassFixture`). DMN files under `test/RulesDoer.Core.Tests/DmnFiles/` are embedded resources loaded at fixture construction time into `DefaultDMNPersistence`.

TCK (Technology Compatibility Kit) tests live in `TCK/Run/TCKTests.cs` and drive compliance levels 2 and 3 against the OMG test suite XML files in `DmnFiles/TCK/`.
