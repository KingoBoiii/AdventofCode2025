# 🎄 Advent of Code 2025 – C# Solutions

This repository contains my solutions for **Advent of Code 2025**, implemented in a **single C# console application**.  
The goal of this project is simplicity: one project, one place for all solutions, supported by **unit tests** that validate the examples provided by Advent of Code.

## ✨ Overview

- All solutions contained in one **.NET 10 console app**
- **Unit tests** for each day's challenges
- Simple and easy to navigate
- Focused on learning and puzzle solving


## 📁 Project Structure

```text
/  
├── AdventOfCode2025/  
│   ├── Program.cs  
│   ├── Day01.cs  
│   ├── Day02.cs   
│   └── ...  
│  
├── AdventOfCode2025.Tests/  
│   ├── Day01Tests.cs  
│   ├── Day02Tests.cs  
│   └── ...  
│  
└── README.md
```


## 🧪 Running Tests

All tests use the example inputs provided by Advent of Code.

Run all tests:
```bash
dotnet test
```

Works in Visual Studio, JetBrains Rider, VS Code, or via CLI.


## ▶️ Running the Console App

The console app is not intended to run individual days directly.  
All validation happens through **unit tests**.

For debugging:
```bash
dotnet run --project AdventOfCode2025
```

…but the primary workflow is test-driven.


## 🧰 Requirements

- .NET 10 SDK  
- Visual Studio (or any C# compatible IDE)

## 🎁 About Advent of Code

Advent of Code is a yearly programming event created by Eric Wastl:  
https://adventofcode.com/2025


## 💡 Why this setup?

- Keeps things simple and avoids unnecessary architecture  
- Unit tests ensure correctness and fast feedback  
- Easy to expand day by day  
- Great for experimentation and learning
