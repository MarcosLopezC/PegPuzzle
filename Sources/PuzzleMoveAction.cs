using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	public sealed partial class Puzzle
	{
		public sealed partial class PuzzleContext
		{
			/// <summary>
			/// Represents a move action on a PuzzleContext.
			/// </summary>
			private sealed class PuzzleMoveAction : IPuzzleMoveAction
			{
				/// <summary>
				/// Gets the PuzzleContext to which this action belongs.
				/// </summary>
				public PuzzleContext Context { get; private set; }

				/// <summary>
				/// Gets the index of the peg that is to be moved in this move.
				/// </summary>
				public int MovedPeg { get; private set; }

				/// <summary>
				/// Gets the index of the peg that is to be removed in this move.
				/// </summary>
				public int RemovedPeg { get; private set; }

				/// <summary>
				/// Gets the index of the spot where the  moved peg will be moved to.
				/// </summary>
				public int MoveToSpot { get; private set; }

				/// <summary>
				/// Initializes a new instance of PuzzleMove.
				/// </summary>
				/// <param name="context">The context in which this move takes place.</param>
				/// <param name="move">The index of the peg that is to be moved.</param>
				/// <param name="to">The index of the spot where the peg will be moved.</param>
				/// <param name="remove">The index of the peg that is to be removed.</param>
				public PuzzleMoveAction(PuzzleContext context, int move, int to, int remove)
				{
					this.Context = context;
					this.MovedPeg = move;
					this.MoveToSpot = to;
					this.RemovedPeg = remove;
				}

				/// <summary>
				/// Executes the move and returns the resulting context.
				/// </summary>
				/// <returns>A PuzzleContext represeting the result of this action.</returns>
				public PuzzleContext Execute()
				{
					if (resultContext != null)
					{
						return resultContext;
					}

					PuzzleContext result = new PuzzleContext(this);

					result.state[MoveToSpot] = result.state[MovedPeg];
					result.state[RemovedPeg] = SpotState.Empty;
					result.state[MovedPeg] = SpotState.Empty;

					result.Pegs -= 1;

					resultContext = result;

					return result;
				}

				public override string ToString()
				{
					return string.Format(
						"Move {0} to {1}. Remove {2}.",
						this.MovedPeg, this.MoveToSpot, this.RemovedPeg
					);
				}

				private PuzzleContext resultContext;
			}
		}
	}
}
