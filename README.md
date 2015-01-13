# PegPuzzle

PegPuzzle is a triangular peg game puzzle solver.
It can find solutions to puzzles of any size (as long as the puzzle has a solution).

## How to build

This program was written in [C# Express 2010](http://www.visualstudio.com/en-us/downloads#d-2010-express).
To build the binaries, you will need to use the same compiler or later.
You might be able to build the source in other environment,
but this might required changes to the original source code.
These are the steps to build the solution:

- Load the solution into Visual C# Express 2010.
- Go to the `Build` menu and select click on `Build Solution` or press `F6`.
- Navigate to `Sources\bin` and you'll see the executable.

## How to use

Upon opening the program, you will be greeted with a empty window.
The first thing you want to do is create a new puzzle to be solved.
Go to the `Puzzle` menu and select `Create...`.
This will open a dialog window where you can select the number of rows and the
initial hole position of the new puzzle.
Press the `Create` button to create the new puzzle.

After a puzzle is create, you can compute a solution for it.
Go to the `Puzzle` menu and select `Solve...` to open the dialog menu.
You can choose to find a solution where the last peg ends in the given position,
or you can choose to find first solution that the program finds.

After solving the puzzle, the actions required to solve the puzzle will be listed on the right.
You can select each action and see the results on the left.
You can use the arrow keys to step through each action and see how it affects the puzzle.

## Known problems

The time required to each puzzle increases exponentially as the number of rows in the puzzle increases.
Puzzle with less than 9 rows can be solved in less than a minute.
However, I have not been able to find a solutions for puzzles larger than 9 rows after waiting more than 20 minutes.

Right now the peg spots enumeration is not displayed on the program.
The enumeration goes the left to right, starting at the top with peg spot 0.
