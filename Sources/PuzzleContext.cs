using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	public sealed partial class Puzzle
	{
		/// <summary>
		/// Represents the state of a puzzle.
		/// </summary>
		public sealed partial class PuzzleContext
		{
			/// <summary>
			/// Gets a reference to the puzzle to which this context belongs.
			/// </summary>
			public Puzzle Puzzle { get; private set; }

			/// <summary>
			/// Gets the number of pegs in the board.
			/// </summary>
			public int Pegs { get; private set; }

			/// <summary>
			/// Gets the action that caused this context.
			/// </summary>
			public IPuzzleAction Cause { get; private set; }

			/// <summary>
			/// Gets the state of a spot.
			/// </summary>
			/// <param name="index">The index of the spot.</param>
			/// <returns>A SpotState value indicating the state of the spot.</returns>
			public SpotState this[int index]
			{
				get
				{
					return state[index];
				}
			}

			/// <summary>
			/// Initializes a new instance of PuzzleContext representing an empty board.
			/// </summary>
			/// <param name="puzzle">A reference to the Puzzle to which this context belongs.</param>
			public PuzzleContext(Puzzle puzzle)
			{
				if (puzzle == null)
				{
					throw new ArgumentNullException();
				}

				this.Puzzle = puzzle;

				this.state = new SpotState[puzzle.Spots];

				for (int i = 0; i < this.state.Length; i += 1)
				{
					this.state[i] = SpotState.Empty;
				}
			}

			/// <summary>
			/// Gets an action that starts the context.
			/// </summary>
			/// <param name="initialHoleSpot">The spot index of the initial hole.</param>
			public IPuzzleAction Start(int initialHoleSpot)
			{
				return new PuzzleStartAction(this, initialHoleSpot);
			}

			/// <summary>
			/// Finds all possible moves on this context and adds it to a stack.
			/// </summary>
			/// <param name="stack">The stack in which to add the possible moves.</param>
			public void FindMoves(Stack<IPuzzleAction> stack)
			{
				if (Pegs > Puzzle.Spots / 2)
				{
					FindMovesOnHoles(stack);
				}
				else
				{
					FindMovesOnPegs(stack);
				}
			}

			/// <summary>
			/// Finds all the moves that can be done on a spot with a peg.
			/// </summary>
			/// <param name="stack">The stack in which to add the moves.</param>
			private void FindMovesOnPegs(Stack<IPuzzleAction> stack)
			{
				int pegsChecked = 0;

				for (int spot = 0; spot < state.Length; spot += 1)
				{
					if (state[spot] != SpotState.Empty)
					{
						MovePair[] table = Puzzle.moveTable[spot];

						for (int i = 0; i < table.Length; i += 1)
						{
							int near = table[i].near;
							int far  = table[i].far;

							if (state[near] != SpotState.Empty && state[far] == SpotState.Empty)
							{
								stack.Push(new PuzzleMoveAction(this, spot, far, near));
							}
						}

						pegsChecked += 1;

						if (pegsChecked >= Pegs)
						{
							break;
						}
					}
				}
			}

			/// <summary>
			/// Finds all the moves that can be done on a spot with no peg.
			/// </summary>
			/// <param name="stack">The stack in which to add the moves.</param>
			private void FindMovesOnHoles(Stack<IPuzzleAction> stack)
			{
				int holesChecked = 0;

				for (int spot = 0; spot < state.Length; spot += 1)
				{
					if (state[spot] == SpotState.Empty)
					{
						MovePair[] table = Puzzle.moveTable[spot];

						for (int i = 0; i < table.Length; i += 1)
						{
							int near = table[i].near;
							int far  = table[i].far;

							if (state[near] != SpotState.Empty && state[far] != SpotState.Empty)
							{
								stack.Push(new PuzzleMoveAction(this, far, spot, near));
							}
						}

						holesChecked += 1;

						if (holesChecked >= Puzzle.Spots - Pegs)
						{
							break;
						}
					}
				}
			}

			/// <summary>
			/// Initializes a new instance of PuzzleContext based on the given Action.
			/// This constructor is intended to be used by an Action.
			/// </summary>
			/// <param name="action">The Action in which to base this context.</param>
			private PuzzleContext(IPuzzleAction action)
			{
				this.Puzzle = action.Context.Puzzle;

				this.Cause = action;

				this.Pegs = action.Context.Pegs;

				// Create a copy of the context the action is based on.
				this.state = new SpotState[action.Context.state.Length];
				for (int i = 0; i < this.state.Length; i++)
				{
					this.state[i] = action.Context.state[i];
				}
			}

			/// <summary>
			/// An array of SpotStates representing the state of the context.
			/// </summary>
			private SpotState[] state;
		}
	}
}
