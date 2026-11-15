# Session 03 — Practice Projects

Code for **Session 03: C# Fundamentals — Types, Control Flow & Arrays**.
Study notes: [`dotnet-backend-session-03-notes.md`](dotnet-backend-session-03-notes.md)

Requires the **.NET 10 SDK** (`dotnet --version` → `10.0.x`).

```text
Session03/
├── dotnet-backend-session-03-notes.md   ← the study notes
├── Demo/                         ← read and run: one project per topic
│   ├── Session03.Demo.slnx
│   ├── Session03.Variables/      notes §3  types, decimal vs double, value vs reference, var, strings
│   ├── Session03.Conversion/     notes §4  implicit/explicit, checked, Convert, cultures, Parse vs TryParse
│   ├── Session03.Conditions/     notes §5  if/else, ternary, switch statement & expression, patterns
│   ├── Session03.Loops/          notes §6  for, nested, while, do-while, foreach, break/continue
│   ├── Session03.Arrays/         notes §7  declare, index, ^1, ranges, Sort/Reverse/IndexOf, 2D
│   └── Session03.CommonMistakes/ notes §9  each mistake shown wrong ❌ and right ✅
└── Lab/                          ← your turn: the assignment, as a starter with TODOs
    ├── Session03.Lab.slnx
    └── Session03.Lab/
```

The **Demo** programs need no keyboard input, so they also run with F5 in VS Code. The **Lab** reads input, so run it in a terminal.

## Visual Studio 2026

1. **File → Open → Project/Solution** → `Demo\Session03.Demo.slnx`.
2. In Solution Explorer, right-click a project (e.g. `Session03.Loops`) → **Set as Startup Project**.
3. **Ctrl+F5** to run, or **F9** on a line then **F5** to debug and step with **F10**.
4. For the lab, open `Lab\Session03.Lab.slnx` (a separate solution) and press **Ctrl+F5**.

## VS Code

```bash
cd Session03/Demo
```

```bash
dotnet run --project Session03.Loops
```

Swap `Session03.Loops` for any other demo project. To debug, open the `Session03` folder (`code .`), open a `Program.cs`, set a breakpoint with **F9**, and press **F5** → **C#**.

For the lab:

```bash
cd Session03/Lab
```

```bash
dotnet run --project Session03.Lab
```

## Build everything

```bash
dotnet build Demo/Session03.Demo.slnx
```

```bash
dotnet build Lab/Session03.Lab.slnx
```

Both should report **0 warnings, 0 errors**.
