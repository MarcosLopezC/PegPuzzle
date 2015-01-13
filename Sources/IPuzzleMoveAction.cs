using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	/// <summary>
	/// Represents a move on a PuzzleContext.
	/// </summary>
	/// <remarks>
	/// A move is an action that follows the rules of the game.
	/// </remarks>
	public interface IPuzzleMoveAction : IPuzzleAction
	{
		/// <summary>
		/// Gets the index of the peg to be moved.
		/// </summary>
		int MovedPeg { get; }

		/// <summary>
		/// Gets the index of the peg to be removed.
		/// </summary>
		int RemovedPeg { get; }

		/// <summary>
		/// Gets the index of the spot where to move the peg.
		/// </summary>
		int MoveToSpot { get; }
	}
}
