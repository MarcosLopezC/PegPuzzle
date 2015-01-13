using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	public sealed partial class Puzzle
	{
		/// <summary>
		/// Gets the number of rows in the puzzle.
		/// </summary>
		public int Rows { get; private set; }

		/// <summary>
		/// Gets the number of spots in the Puzzle.
		/// </summary>
		public int Spots { get; private set; }

		/// <summary>
		/// Gets a reference to the current context of the puzzle.
		/// </summary>
		public PuzzleContext Context { get; private set; }

		/// <summary>
		/// Initializes a new instance of a Puzzle being empty.
		/// </summary>
		/// <param name="rows">The number of rows in the puzzle.</param>
		public Puzzle(int rows)
		{
			if (rows < 1)
			{
				throw new ArgumentOutOfRangeException();
			}

			this.Rows = rows;

			this.Spots = GetMaxSpotCount(rows);

			this.Context = new PuzzleContext(this);

			BuildMoveTable();
		}

		/// <summary>
		/// Initializes a new instance of a Puzzle and populates the board with an initial state.
		/// </summary>
		/// <param name="rows">The number of rows in the puzzle.</param>
		/// <param name="initialHoleSpot">The spot index of the initial hole.</param>
		public Puzzle(int rows, int initialHoleSpot) : this(rows)
		{
			this.Context = Context.Start(initialHoleSpot).Execute();
		}

		/// <summary>
		/// Changes the current context of the puzzle.
		/// </summary>
		/// <param name="context">The context to change to.</param>
		public void SetContext(PuzzleContext context)
		{
			if (context.Puzzle != this)
			{
				throw new ArgumentException();
			}
			else
			{
				this.Context = context;
			}
		}

		/// <summary>
		/// Gets the index of the first spot in a given row.
		/// </summary>
		/// <param name="row">The row index.</param>
		/// <returns>The index of the first spot in a row.</returns>
		public static int GetFirstRowSpot(int row)
		{
			// f(x) = (x^2 + x) / 2
			return (row * row + row) / 2;
		}

		/// <summary>
		/// Gets the maximum number of spots in a puzzle of a given size.
		/// </summary>
		/// <param name="rows">The number of rows in the puzzle</param>
		/// <returns>The maximum number of spots in a puzzle.</returns>
		public static int GetMaxSpotCount(int rows)
		{
			return GetFirstRowSpot(rows + 1);
		}

		/// <summary>
		/// Gets the row number (0-based) where the given spot resides.
		/// </summary>
		/// <param name="index">The spot index.</param>
		/// <returns>The row where the spot resides.</returns>
		public static int GetSpotRow(int index)
		{
			// Row = (sqrt(8x+1)-1)/2
			return (int)((Math.Sqrt(8 * index + 1) - 1) / 2);
		}

		/// <summary>
		/// Gets the column index of a given spot index.
		/// </summary>
		/// <param name="index">The index of the spot.</param>
		/// <returns>The column index.</returns>
		/// <remarks>
		/// Use the overloaded version of this method that takes a row for faster performance.
		/// </remarks>
		public static int GetSpotColumn(int index)
		{
			return GetSpotColumn(index, GetSpotRow(index));
		}

		/// <summary>
		/// Gets the column index of a given spot index.
		/// </summary>
		/// <param name="index">The index of the spot.</param>
		/// <param name="row">The row of the given spot.</param>
		/// <returns>The column index.</returns>
		public static int GetSpotColumn(int index, int row)
		{
			int offset = (index - GetFirstRowSpot(row)) * 2;

			// Row number coincides with the maximum column size.
			return offset - row;
		}

		/// <summary>
		/// Gets the coordinate of a given spot.
		/// </summary>
		/// <param name="index">The index of the spot.</param>
		/// <returns>The coordinate of the spot.</returns>
		public static SpotCoordinate GetSpotCoordinate(int index)
		{
			SpotCoordinate spot;

			spot.row = GetSpotRow(index);
			spot.column = GetSpotColumn(index, spot.row);

			return spot;
		}

		/// <summary>
		/// Determines whether the coordinate is valid.
		/// </summary>
		/// <param name="spot">The coordinate of the spot to test.</param>
		/// <returns>A value indicating whether the coordinate is valid.</returns>
		public bool IsSpotValid(SpotCoordinate spot)
		{
			if (spot.row < 0 || spot.row > this.Rows || Math.Abs(spot.column) > spot.row)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// Gets the index of a spot given its coordinate.
		/// </summary>
		/// <param name="coordinate">The coordinate of the spot.</param>
		/// <returns>The index of the spot.</returns>
		public static int GetSpotIndex(SpotCoordinate coordinate)
		{
			int first = GetFirstRowSpot(coordinate.row);

			int offset = (coordinate.row + coordinate.column) / 2;

			return first + offset;
		}

		/// <summary>
		/// Gets the number of spots in a given row (0-based).
		/// </summary>
		/// <param name="row">The row number.</param>
		/// <returns>The number of spots in a row.</returns>
		public static int GetRowSpotCount(int row)
		{
			return row + 1;
		}

		/// <summary>
		/// Builds a table of valid move for later use.
		/// </summary>
		private void BuildMoveTable()
		{
			moveTable = new MovePair[Spots][];

			for (int i = 0; i < moveTable.Length; i += 1)
			{
				BuildMovesOnSpot(i);
			}
		}

		/// <summary>
		/// Builds a table of moves on a given spot.
		/// </summary>
		/// <param name="spot">The index of the spot.</param>
		private void BuildMovesOnSpot(int spot)
		{
			List<MovePair> movements = new List<MovePair>(8);

			SpotCoordinate coordinate = GetSpotCoordinate(spot);

			// If the MovePair is valid, it gets added to the list.
			Action<SpotCoordinate, SpotCoordinate> CheckMovePair =
				(SpotCoordinate near, SpotCoordinate far) =>
				{
					if (IsSpotValid(far) && IsSpotValid(near))
					{
						MovePair move;

						move.near = GetSpotIndex(near);
						move.far = GetSpotIndex(far);

						movements.Add(move);
					}
				};

			Action<SpotCoordinate> findMovePairOnDirection =
				(SpotCoordinate vector) =>
				{
					CheckMovePair(coordinate.Offset(vector.row, vector.column),
						coordinate.Offset(vector.row * 2, vector.column * 2));
				};

			findMovePairOnDirection(new SpotCoordinate(-2, 0)); // May not be valid.
			findMovePairOnDirection(new SpotCoordinate(-1, 1));
			findMovePairOnDirection(new SpotCoordinate(0, 2));
			findMovePairOnDirection(new SpotCoordinate(1, 1));
			findMovePairOnDirection(new SpotCoordinate(2, 0));
			findMovePairOnDirection(new SpotCoordinate(1, -1));
			findMovePairOnDirection(new SpotCoordinate(0, -2)); // May not be valid.
			findMovePairOnDirection(new SpotCoordinate(-1, -1));

			moveTable[spot] = movements.ToArray();
		}

		/// <summary>
		/// A table used to resolve moves in the puzzle.
		/// The first index is the hole in question.
		/// The second is used to iterate through the possible moves.
		/// </summary>
		private MovePair[][] moveTable;
	}
}
