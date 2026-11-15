// Session 03 · Demo 3 · Conditions  (notes §5)
// Run: dotnet run --project Session03.Conditions

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 03 · Conditions ===\n");

// ===== 5.1 if / else if / else (notes §5.1) =====
// The first true condition wins.
Console.WriteLine("--- 5.1 if / else if / else ---");

int[] scores = { 95, 75, 40 };
foreach (int score in scores)
{
    string result;
    if (score >= 90)
    {
        result = "A";
    }
    else if (score >= 75)
    {
        result = "B";
    }
    else
    {
        result = "C or below";
    }
    Console.WriteLine($"score {score} → {result}");
}
Console.WriteLine();

// ===== 5.2 Ternary ? : (notes §5.2) =====
Console.WriteLine("--- 5.2 Ternary ---");

int examScore = 62;
string passFail = examScore >= 50 ? "Pass" : "Fail";
Console.WriteLine($"examScore {examScore} → {passFail}");

int age = 16;
string access = age >= 18 ? "Access granted" : "Access denied";
Console.WriteLine($"age {age} → {access}");
Console.WriteLine();

// ===== 5.3 switch statement (notes §5.3) =====
Console.WriteLine("--- 5.3 switch statement ---");

string[] days = { "Saturday", "Monday", "Wednesday" };
foreach (string day in days)
{
    switch (day)
    {
        case "Saturday":
        case "Sunday":            // empty cases can share code
            Console.WriteLine($"{day} → Weekend");
            break;
        case "Monday":
            Console.WriteLine($"{day} → Back to work");
            break;
        default:
            Console.WriteLine($"{day} → Weekday");
            break;
    }
}

// A missing break doesn't fall through in C#; it doesn't compile:
//   case "Monday":
//       Console.WriteLine("Back to work");   // no break
//   case "Tuesday": ...
//   error CS0163: Control cannot fall through from one case label to another
Console.WriteLine();

// ===== 5.4 switch expression (notes §5.4) =====
// Returns a value. No break. _ = anything else.
Console.WriteLine("--- 5.4 switch expression ---");

foreach (string day in days)
{
    string type = day switch
    {
        "Saturday" or "Sunday" => "Weekend",
        "Monday"               => "Back to work",
        _                      => "Weekday"
    };
    Console.WriteLine($"{day} → {type}");
}

// Enum → text (the enum is at the bottom of the file).
TaskStatus[] statuses = { TaskStatus.Pending, TaskStatus.InProgress, TaskStatus.Completed };
foreach (TaskStatus status in statuses)
{
    string label = status switch
    {
        TaskStatus.Pending   => "Not started",
        TaskStatus.Completed => "Done",
        _                    => "In progress"
    };
    Console.WriteLine($"TaskStatus.{status} → {label}");
}

// Relational patterns, checked top to bottom.
foreach (int score in scores)
{
    string letter = score switch
    {
        >= 90 => "A",
        >= 75 => "B",
        _     => "C or below"
    };
    Console.WriteLine($"score {score} → {letter}  (switch expression)");
}

// 'and' makes a range.
int temperature = 22;
string feel = temperature switch
{
    < 10           => "Cold",
    >= 10 and < 25 => "Nice",
    _              => "Hot"
};
Console.WriteLine($"temperature {temperature} → {feel}");

Console.WriteLine("\nDone. Next: Session03.Loops");

// Types must come after the top-level code.
enum TaskStatus
{
    Pending,
    InProgress,
    Completed
}
