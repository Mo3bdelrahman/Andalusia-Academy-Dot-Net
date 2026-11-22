# Session 05 — Practice Projects

Code for **Session 05: OOP I — Classes, Encapsulation & Inheritance**.
Study notes: [`dotnet-backend-session-05-notes.md`](dotnet-backend-session-05-notes.md)

Requires the **.NET 10 SDK** (`dotnet --version` → `10.0.x` or newer).

```text
Session05/
├── dotnet-backend-session-05-notes.md   ← the study notes
├── Demo/                                ← read and run: one project per topic
│   ├── Session05.Demo.slnx
│   ├── Session05.ClassesObjects/     notes §3   class vs object, new, initializers, required, references
│   ├── Session05.Constructors/       notes §4   constructors, this(...) chaining, this, primary constructors
│   ├── Session05.Properties/         notes §5   access modifiers, auto/full/computed properties, init, field
│   ├── Session05.StaticMembers/      notes §6   static class, const, shared counter
│   ├── Session05.Inheritance/        notes §7   Animal → Dog/Cat, base(...), constructor order
│   ├── Session05.Polymorphism/       notes §8   virtual/override, base.Method(), new (hiding), sealed, ToString
│   └── Session05.CommonMistakes/     notes §10  each mistake shown wrong ❌ and right ✅
└── Lab/                                 ← your turn: starters with TODOs
    ├── Session05.Lab.slnx
    ├── Session05.Lab/                notes §12  in-session lab: WorkItem → TaskItem, BugReport
    └── Session05.Assignment/         notes §13  assignment: BankAccount → SavingsAccount
```

Each project keeps its classes in a `Models/` folder (one class per file). No program reads keyboard input, so they all run with F5 in VS Code too.

## Visual Studio 2026

1. **File → Open → Project/Solution** → `Demo\Session05.Demo.slnx`.
2. In Solution Explorer, right-click a project (e.g. `Session05.Polymorphism`) → **Set as Startup Project**.
3. **Ctrl+F5** to run, or **F9** on a line then **F5** to debug and step into methods with **F11**.
4. For the lab and the assignment, open `Lab\Session05.Lab.slnx` (a separate solution) and set `Session05.Lab` or `Session05.Assignment` as the startup project.

## VS Code

```bash
cd Session05/Demo
```

```bash
dotnet run --project Session05.Polymorphism
```

Swap `Session05.Polymorphism` for any other demo project. To debug, open the `Session05` folder (`code .`), open a `Program.cs`, set a breakpoint with **F9**, and press **F5** → **C#**.

For the lab and the assignment:

```bash
cd Session05/Lab
```

```bash
dotnet run --project Session05.Lab
```

```bash
dotnet run --project Session05.Assignment
```

## Build everything

```bash
dotnet build Demo/Session05.Demo.slnx
```

```bash
dotnet build Lab/Session05.Lab.slnx
```

Both should report **0 warnings, 0 errors**.
