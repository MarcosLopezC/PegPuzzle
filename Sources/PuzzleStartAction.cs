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
			private sealed class PuzzleStartAction : IPuzzleAction
			{
				/// <summary>
				/// Gets a reference to the context of this action.
				/// </summary>
				public PuzzleContext Context { get; private set; }

				/// <summary>
				/// Gets the spot index of the initial hole.
				/// </summary>
				public int InitialHoleSpot { get; private set; }

				/// <summary>
				/// Initializes a new instance of PuzzleStartAction.
				/// </summary>
				/// <param name="context">The context to which this action belongs.</param>
				/// <param name="initialHoleSpot">The spot index of the initial hole.</param>
				public PuzzleStartAction(PuzzleContext context, int initialHoleSpot)
				{
					this.Context = context;
					this.InitialHoleSpot = initialHoleSpot;
				}

				/// <summary>
				/// Executes the action and returns the resulting context.
				/// </summary>
				public PuzzleContext Execute()
				{
					PuzzleContext result = new PuzzleContext(this);

					int index = 0;

					for (int row = 0, max = result.Puzzle.Rows + 1; row < max; row += 1)
					{
						SpotState color = GetRowColor(row);

						for (int i = 0, length = Puzzle.GetRowSpotCount(row); i < length; i += 1)
						{
							result.state[index] = color;

							index += 1;
						}
					}

					result.state[this.InitialHoleSpot] = SpotState.Empty;

					result.Pegs = result.Puzzle.Spots - 1;

					return result;
				}

				public override string ToString()
				{
					return string.Format("Game start. Initial hole in spot {0}", this.InitialHoleSpot);
				}

				/// <summary>
				/// Gets a SpotState represeting a color given a row.
				/// </summary>
				/// <param name="row">The row number.</param>
				/// <returns>A SpotState value represeting a color.</returns>
				private SpotState GetRowColor(int row)
				{
					row %= 3;

					switch (row)
					{
						case 0:
							return SpotState.RedPeg;

						case 1:
							return SpotState.GreenPeg;

						case 2:
							return SpotState.BluePeg;

						default:
							throw new InvalidOperationException();
					}
				}
			}
		}
	}
}
