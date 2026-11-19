# Session 04 — Practice Projects

Code for **Session 04: C# Methods, Strings & Exception Handling**.
Study notes: [`dotnet-backend-session-04-notes.md`](dotnet-backend-session-04-notes.md)

Requires the **.NET 10 SDK** (`dotnet --version` → `10.0.x`).

```text
Session04/
├── dotnet-backend-session-04-notes.md   ← the study notes
├── Demo/                                ← read and run: one project per topic
│   ├── Session04.Demo.slnx
│   ├── Session04.Methods/            notes §3  structure, =>, overloading, optional/named, ref/out, tuples
│   ├── Session04.Strings/            notes §4  immutability, common methods, comparing, StringBuilder
│   ├── Session04.Nulls/              notes §5  int?, string?, ??, ??=, ?., null checks
│   ├── Session04.ExceptionHandling/  notes §6  try/catch/finally, throw, throw; vs throw ex;, custom exception
│   │   └── Exceptions/InsufficientFundsException.cs
│   └── Session04.CommonMistakes/     notes §8  each mistake shown wrong ❌ and right ✅
└── Lab/                                 ← your turn: the Safe Calculator, as a starter with TODOs
    ├── Session04.Lab.slnx
    └── Session04.Lab/
        └── Exceptions/InvalidExpressionException.cs
```

The **Demo** programs need no keyboard input, so they also run with F5 in VS Code. The **Lab** reads input, so run it in a terminal.

## Visual Studio 2026

1. **File → Open → Project/Solution** → `Demo\Session04.Demo.slnx`.
2. In Solution Explorer, right-click a project (e.g. `Session04.ExceptionHandling`) → **Set as Startup Project**.
3. **Ctrl+F5** to run, or **F9** on a line then **F5** to debug and step with **F10** / **F11**.
4. For the lab, open `Lab\Session04.Lab.slnx` (a separate solution) and press **Ctrl+F5**.

## VS Code

```bash
cd Session04/Demo
```

```bash
dotnet run --project Session04.ExceptionHandling
```

Swap `Session04.ExceptionHandling` for any other demo project. To debug, open the `Session04` folder (`code .`), open a `Program.cs`, set a breakpoint with **F9**, and press **F5** → **C#**.

For the lab:

```bash
cd Session04/Lab
```

```bash
dotnet run --project Session04.Lab
```

## Build everything

```bash
dotnet build Demo/Session04.Demo.slnx
```

```bash
dotnet build Lab/Session04.Lab.slnx
```

Both should report **0 warnings, 0 errors**.
