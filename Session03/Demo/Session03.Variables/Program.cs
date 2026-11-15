// Session 03 · Demo 1 · Variables & Data Types  (notes §3)
// Run: dotnet run --project Session03.Variables

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 03 · Variables & Data Types ===\n");

// ===== 3.1 Value types (notes §3.1) =====
Console.WriteLine("--- 3.1 Value types ---");

int age = 25;                      // whole number
var bb = 50;
bb = 60;
long population = 8_000_000_000L;  // big whole number (L = long, _ is just for reading)
double price = 9.99;               // decimal number (approximate)
decimal tax = 0.15m;               // exact decimal (m = decimal)
float ratio = 0.5f;                // f = float
bool isActive = true;              // true / false
char grade = 'A';                  // one character

Console.WriteLine($"int     age        = {age}");
Console.WriteLine($"long    population = {population}");
Console.WriteLine($"double  price      = {price}");
Console.WriteLine($"decimal tax        = {tax}");
Console.WriteLine($"float   ratio      = {ratio}");
Console.WriteLine($"bool    isActive   = {isActive}");
Console.WriteLine($"char    grade      = {grade}");
Console.WriteLine($"int range : {int.MinValue} .. {int.MaxValue}");

// double can't store 0.1 exactly, decimal can → use decimal for money.
double dSum = 0.1 + 0.2;
decimal mSum = 0.1m + 0.2m;
Console.WriteLine($"double : 0.1 + 0.2 = {dSum:R}  → equals 0.3? {dSum == 0.3}");
Console.WriteLine($"decimal: 0.1 + 0.2 = {mSum}  → equals 0.3? {mSum == 0.3m}");
Console.WriteLine("Rule: use decimal for money and prices.\n");

// ===== 3.2 Reference types & copying (notes §3.2) =====
Console.WriteLine("--- 3.2 Reference types & copying ---");

string name = @"A\lice";
object anything = 42;              // object can hold any type
Console.WriteLine($"string name     = {name}");
Console.WriteLine($"object anything = {anything}  (actual type: {anything.GetType().Name})");

// Value type: the copy is independent.
int a = 25;
int b = a;
b = 30;
Console.WriteLine($"Value type    : a = {a}, b = {b}   ← a is still 25");

// Reference type: both variables point to the same array.
int[] x = { 1, 2, 3 };
int[] y = x;
y[0] = 99;
Console.WriteLine($"Reference type: x[0] = {x[0]}, y[0] = {y[0]}  ← x changed too!");

// Strings are immutable: += makes a new string.
string s1 = "Hi";
string s2 = s1;
s2 += "!";
Console.WriteLine($"Strings       : s1 = {s1}, s2 = {s2}  ← s1 unchanged (immutable)\n");

// ===== 3.3 Stack vs heap (notes §3.3) =====
Console.WriteLine("--- 3.3 Stack vs heap ---");

// n lives on the stack. The array lives on the heap; arr only holds a reference to it.
int n = 1;
int[] arr = { 1 };
Change(n, arr);                    // Change gets its own stack frame
Console.WriteLine($"after Change: n = {n}, arr[0] = {arr[0]}");   // 1, 99
Console.WriteLine("n was copied into Change's frame; arr's reference pointed to the same heap array.");

int total = Add(2, 3);             // Add's frame is removed when it returns
Console.WriteLine($"Add(2, 3) = {total}\n");

// ===== 3.4 var (notes §3.4) =====
Console.WriteLine("--- 3.4 var ---");

var count = 10;                    // int
var cost = 9.99m;                  // decimal
var label = "Hello";               // string
Console.WriteLine($"var count = 10    → {count.GetType().Name}");
Console.WriteLine($"var cost  = 9.99m → {cost.GetType().Name}");
Console.WriteLine($"var label = \"Hello\" → {label.GetType().Name}");

// var is still a fixed type. These don't compile:
//   var z = 1;  z = "hello";   // CS0029: cannot convert string to int
//   var w;                     // CS0818: must be initialized
Console.WriteLine();

// ===== 3.5 Strings (notes §3.5) =====
Console.WriteLine("--- 3.5 Strings ---");

string firstName = "Alice";
int year = 2025;

string message = $"Hello, {firstName}! Born in {year - 25}.";   // $ = interpolation
Console.WriteLine($"Interpolated : {message}");
Console.WriteLine($"Formatted    : price {price:F2}, population {population:N0}");   // F2, N0 = formats

string escaped = "C:\\Users\\Alice\\notes.txt";      // \\ = one backslash
string path = @"C:\Users\Alice\Documents\notes.txt"; // @ = verbatim, no escaping
Console.WriteLine($"Escaped      : {escaped}");
Console.WriteLine($"Verbatim     : {path}");

string userName = "Alice";
Console.WriteLine($@"Both $@      : C:\Users\{userName}\files");

string multiLine = @"Line one
Line two";
Console.WriteLine($"Multi-line   :\n{multiLine}");

// Raw string (C# 11+): """ ... """, values go in {{ }} when using $$.
string json = $$"""
    { "name": "{{firstName}}", "year": {{year}} }
    """;
Console.WriteLine($"Raw JSON     : {json}");

Console.WriteLine("\nDone. Next: Session03.Conversion");

// ----- Methods used in §3.3 -----
static void Change(int value, int[] items)
{
    value = 99;      // changes only the copy in this frame
    items[0] = 99;   // changes the shared array on the heap
}

static int Add(int first, int second)
{
    int sum = first + second;   // first, second, sum live in Add's frame
    return sum;
}
