// Session 05 · LAB (starter) · WorkItem Class Hierarchy  (notes §12)
// Run: dotnet run --project Session05.Lab
// Build WorkItem → TaskItem and BugReport in the Models folder, then use them here.
// Stuck? See Session05.Inheritance and Session05.Polymorphism in the Demo solution.

using Session05.Lab.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 Lab · WorkItems ===\n");

// TODO 4a: create at least one TaskItem and one BugReport (object initializers work well).
// HINT: new TaskItem { Id = 1, Title = "Write notes", CreatedAt = DateTime.Now, DueDate = null }

// TODO 4b: store them in a WorkItem[] and loop over it, printing item.Summarize().
// HINT: the variable type is WorkItem, but each object's own override runs (notes §8.2).
Console.WriteLine("TODO: create the items and print each summary");

Console.WriteLine("\nDone.");
