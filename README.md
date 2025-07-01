# OldPhonePad

# OldPhonePad

A coding challenge solution that simulates old mobile phone keypad input to generate text. This console application processes numeric input (e.g., `"4433555 555666#"`), supports backspacing with `*`, and ends input on `#`.

---

## 🛠️ Features

- T9-style keypad character mapping
- Supports:
  - Multi-press input (e.g., `2` → A, `22` → B, etc.)
  - Backspace via `*`
  - Pause between same-button letters using a space (` `)
  - Terminates input with `#`
- Designed with clean architecture:
  - Core logic in a reusable class library
  - Dependency injection through a separate DI project
  - Unit tested using **xUnit** and **Shouldly**

---
Project Structure
OldPhonePad.sln
│
├── OldPhonePad.ConsoleApp # Console UI entry point
│ └── Program.cs
│
├── OldPhonePad.Core # Main logic & interfaces
│ └── Services
│ └── OldPhonePadService.cs
│ └── Interfaces
│ └── IOldPhonePadService.cs
│
├── OldPhonePad.DependencyInjection # Service registration extension
│ └── DependencyRegistrar.cs
│
├── OldPhonePad.Models # Any future DTOs or config objects
│
├── OldPhonePad.Tests # xUnit + Shouldly test project
│ └── OldPhonePadServiceTests.cs
│
└── README.md

## 🚀 Getting Started

### Prerequisites

### Run the app

```bash
dotnet run --project OldPhonePad.ConsoleApp
