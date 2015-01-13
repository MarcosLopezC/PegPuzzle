using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	/// <summary>
	/// Represents a puzzle solver.
	/// </summary>
	public class PuzzleSolver
	{
		/// <summary>
		/// Gets a reference to the puzzle to be solved.
		/// </summary>
		public Puzzle Puzzle { get; private set; }

		/// <summary>
		/// Initializes a new instance of PuzzleSolver.
		/// </summary>
		/// <param name="puzzle">The Puzzle to be solved.</param>
		public PuzzleSolver(Puzzle puzzle)
		{
			if (puzzle == null)
			{
				throw new ArgumentNullException();
			}

			this.Puzzle = puzzle;
		}

		public List<IPuzzleAction> Solve()
		{
			return Solve(x => x.Pegs == 1);
		}

		public List<IPuzzleAction> Solve(int goalIndex)
		{
			return Solve(x => x.Pegs == 1 && x[goalIndex] != SpotState.Empty);
		}

		/// <summary>
		/// Returns a list of action required to puzzle satisfy the given condition.
		/// </summary>
		/// <param name="condition">The condition to test.</param>
		private List<IPuzzleAction> Solve(Predicate<Puzzle.PuzzleContext> condition)
		{
			Stack<IPuzzleAction> stack = new Stack<IPuzzleAction>();

			// Fill the stack with the initial actions.
			Puzzle.Context.FindMoves(stack);

			while (stack.Count > 0)
			{
				IPuzzleAction action = stack.Pop();

				Puzzle.PuzzleContext context = action.Execute();

				// Check if context is goal.
				if (condition(context) == true)
				{
					return BuildSolutionList(context.Cause);
				}

				context.FindMoves(stack);
			}

			return null;
		}

		/// <summary>
		/// Returns a list of action required to get to the given action.
		/// </summary>
		/// <param name="solution">The action that leads to a solution.</param>
		private List<IPuzzleAction> BuildSolutionList(IPuzzleAction solution)
		{
			List<IPuzzleAction> actions = new List<IPuzzleAction>();

			for (IPuzzleAction action = solution; action != null; action = action.Context.Cause)
			{
				actions.Add(action);
			}

			actions.Reverse();

			return actions;
		}
	}
}
