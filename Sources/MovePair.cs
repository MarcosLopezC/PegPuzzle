using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegPuzzle
{
	/// <summary>
	/// Represents the indexes of the pair of pegs
	/// required to make a valid move.
	/// </summary>
	public struct MovePair
	{
		public int near;
		public int far;

		public override string ToString()
		{
			return string.Format("Near: {0}; Far: {1}", near, far);
		}
	}
}
