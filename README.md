# Number Guessing Game and Grade Tracker
 
Two small C# console applications, each with its own xUnit test project.
 
| App | What it does |
|---|---|
| **GuessingGame** | The computer picks a random number from 1 to 100. The player guesses within a chosen number of attempts and gets "too high" / "too low" hints. |
| **GradeTracker** | Stores student names and scores in arrays, then reports each student's grade plus the average, highest and lowest score. A menu repeats until the user quits. |
 
---
 
## Features
 
### GuessingGame
- Random secret number between 1 and 100
- Player chooses how many attempts they get
- "Too high" / "Too low" hints after each wrong guess
- Input validation (non-numbers and non-positive attempt counts are rejected)
- Win or game-over message at the end
### GradeTracker
- Stores names and scores in arrays (3 students)
- Score validation: must be a number from 0 to 100
- Grade for each student (see the grading scale below)
- Average, highest and lowest score
- Menu that repeats until the user chooses Quit
**Grading scale**
 
| Score | Grade |
|---|---|
| 80 to 100 | A |
| 70 to 79 | B+ |
| 60 to 69 | B |
| 50 to 59 | C |
| Below 50 | D |
 
---
 
## Prerequisites
 
- [.NET SDK 10.0](https://dotnet.microsoft.com/download) (both projects target `net10.0`)
- Any terminal (Command Prompt, PowerShell, bash) or Visual Studio 2022+ / VS Code
Check your install:
 
```
dotnet --version
```
 
---
 
## Project structure
 
```
Number Guessing Game and Grade Tracker/
├── GuessingGame/
│   ├── GuessingGame.csproj
│   ├── Program.cs
│   └── GuessingGame.Tests/
│       ├── GuessingGame.Tests.csproj
│       └── UnitTest1.cs
└── GradeTracker/
    ├── GradeTracker.csproj
    ├── Program.cs
    └── GradeTracker.Tests/
        ├── GradeTracker.Tests.csproj
        └── UnitTest1.cs
```
 
Each test project sits **inside** its app's folder. See the design notes below for why this matters.
 
---
 
## Setup and running
 
Run each app from its own folder.
 
**Guessing game**
 
```
cd GuessingGame
dotnet run
```
 
**Grade tracker**
 
```
cd GradeTracker
dotnet run
```
 
### Example: GradeTracker
 
```
========== GRADE TRACKER ==========
1. Enter student names and scores
2. View full grade report
3. View average, highest and lowest
4. Quit
Choose an option:
```
 
Choose `1` first to enter data. Options 2 and 3 show a message if no data has been entered yet.
 
---
 
## Running the tests
 
From the app's folder, name the test project explicitly:
 
```
cd GuessingGame
dotnet test GuessingGame.Tests
```
 
```
cd GradeTracker
dotnet test GradeTracker.Tests
```
 
## Architecture and design
 
### Separation of logic and I/O
Both apps split pure logic from console interaction:
 
- **Pure logic**: `IsCorrectGuess`, `CalculateAverage`, `FindHighestScore`, `FindLowestScore`, `GetGrade`. These take values in and return values out, with no console access, so they are easy to unit test. They are `public static` so the test projects can call them.
- **Console I/O**: input methods (`GetPlayerGuess`, `GetMaxAttempts`, `GetScoreInput`, `EnterStudentData`), menu and report display. These stay private.
### GuessingGame flow
`Main` → `PlayGame` → loop of `GetPlayerGuess` + `IsCorrectGuess` until the player wins or runs out of attempts.
 
### GradeTracker flow
`Main` runs a `while (running)` loop that shows a menu and uses a `switch` to dispatch to the right method. A `dataEntered` flag prevents reports from showing empty data. Names and scores are parallel arrays: index `i` in `studentNames` matches index `i` in `scores`.
 
## Assumptions
 
- The secret number is always between 1 and 100 inclusive.
- Valid guesses are whole numbers; the game does not reject numbers outside 1 to 100, they are simply wrong guesses.
- Scores are valid between 0 and 100 inclusive and may have decimals.
- The grade tracker handles exactly 3 students.
- The grading scale above is fixed in code.

## Known limitations
 
- **Fixed class size:** GradeTracker supports only 3 students; changing it means editing the array sizes.
- **No persistence:** Data is lost when the app closes. Nothing is saved to a file or database.
- **Re-entering data overwrites everything:** Menu option 1 replaces all existing names and scores.
- **Names are not validated:** Empty or duplicate names are accepted.

## Possible improvements
 
- Let the user choose the number of students in GradeTracker, or use `List<T>`
- Save and load records to a file

 
