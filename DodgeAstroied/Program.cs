global using System;
global using System.Numerics;
global using Raylib_cs;
global using R = Raylib_cs.Raylib;
global using System.Timers;
global using System.IO;

string age, gender, music;
List<int> results = new();

Setup();
Loop();

void Setup()
{
    R.InitWindow(1600, 800, "JumpMaster");
    R.SetTargetFPS(60);

    Console.Clear();
    gender = Console.ReadLine();
    age = Console.ReadLine();
    music = Console.ReadLine();
}

void Loop()
{
    for (var i = 0; i < 5; i++)
    {
        Game game = new();
        results.Add(game.Run());
    }
    Sum();
}

void Sum()
{
    string newRow = $"{gender}, {age}, {music}, ";

    foreach (var v in results)
    {
        newRow += v + ", ";
    }

    int avg = (int)results.Average();
    int best = results.Max();
    newRow += $"{best}, {avg}";

    File.AppendAllText("values.txt", "\n" + newRow);
}