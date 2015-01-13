using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	/// <summary>
	/// Represents an Action on an PuzzleContext.
	/// </summary>
	public interface IPuzzleAction
	{
		/// <summary>
		/// Gets the PuzzleContext to which this action belongs.
		/// </summary>
		Puzzle.PuzzleContext Context { get; }

		/// <summary>
		/// Executes the action and returns the resulting context.
		/// </summary>
		Puzzle.PuzzleContext Execute();
	}
}
