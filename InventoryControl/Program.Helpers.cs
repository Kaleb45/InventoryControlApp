using System;
using static System.Console;
partial class Program
{
    public static void SectionTitle(string title)
    {
        ConsoleColor backgroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Green;
        WriteLine("*");
        WriteLine($"* {title}");
        ForegroundColor = backgroundColor;
    }

    public static void Fail(string message)
    {
        ConsoleColor backgroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Red;
        WriteLine("*");
        WriteLine($"* {message}");
        ForegroundColor = backgroundColor;
    }

    public static void Info(string message)
    {
        ConsoleColor backgroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine($"Info > {message}");
        ForegroundColor = backgroundColor;
    }
}