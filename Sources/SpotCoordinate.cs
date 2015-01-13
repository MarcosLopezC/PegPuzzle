using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	/// <summary>
	/// Represents the location of a spot in a puzzle.
	/// </summary>
	public struct SpotCoordinate
	{
		public int row;
		public int column;

		public SpotCoordinate(int row, int column)
		{
			this.row    = row;
			this.column = column;
		}

		/// <summary>
		/// Returns a coordinate offset.
		/// </summary>
		/// <param name="rowOffset">The number of row offsets.</param>
		/// <param name="columnOffset">The number of column offsets.</param>
		public SpotCoordinate Offset(int rowOffset, int columnOffset)
		{
			return new SpotCoordinate(this.row + rowOffset, this.column + columnOffset);
		}

		public override string ToString()
		{
			return string.Format("Row: {0}; Column: {1}", row, column);
		}
	}
}
