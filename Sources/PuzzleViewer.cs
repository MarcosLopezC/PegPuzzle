using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PegPuzzle
{
	public partial class PuzzleViewer : UserControl
	{
		public Puzzle Puzzle
		{
			get
			{
				return puzzle;
			}
			set
			{
				puzzle = value;
				SetupSpots();
			}
		}

		public PuzzleViewer()
		{
			InitializeComponent();
		}

		public void UpdatePuzzleView()
		{
			if (Puzzle != null)
			{
				for (int i = 0; i < Puzzle.Spots; i += 1)
				{
					switch (Puzzle.Context[i])
					{
						case SpotState.Empty:
							spotPictures[i].Image = Properties.Resources.Empty;
							break;

						case SpotState.RedPeg:
							spotPictures[i].Image = Properties.Resources.Red;
							break;

						case SpotState.GreenPeg:
							spotPictures[i].Image = Properties.Resources.Green;
							break;

						case SpotState.BluePeg:
							spotPictures[i].Image = Properties.Resources.Blue;
							break;

						default:
							throw new InvalidOperationException();
					}
				}
			}
		}

		private void SetupSpots()
		{
			Controls.Clear();

			if (Puzzle != null)
			{
				spotPictures = new PictureBox[Puzzle.Spots];

				for (int i = 0; i < spotPictures.Length; i += 1)
				{
					var picture = new PictureBox();
					spotPictures[i] = picture;
					picture.Size = new Size(40, 40);
					Controls.Add(picture);
				}

				int leftMostSpotX = Puzzle.GetSpotCoordinate(Puzzle.GetFirstRowSpot(Puzzle.Rows)).column * space;
				this.AutoScrollMinSize = new System.Drawing.Size(Math.Abs(leftMostSpotX * 2), Puzzle.Rows * space);

				AlignSpots();
				UpdatePuzzleView();
			}
			else
			{
				spotPictures = null;
			}
		}

		private void AlignSpots()
		{
			int xCenter;

			if (this.Size.Width < this.AutoScrollMinSize.Width)
			{
				xCenter = (AutoScrollMinSize.Width + space) / 2;
			}
			else
			{
				xCenter = this.Size.Width / 2;
			}

			for (int i = 0; i < spotPictures.Length; i += 1)
			{
				var coordinate = Puzzle.GetSpotCoordinate(i);

				spotPictures[i].Location = new Point(
					x: (xCenter + (coordinate.column * space)) - spotPictures[i].Width / 2,
					y: ((coordinate.row * space) + space)// - spotPictures[i].Height / 2
				);
			}
		}

		private Puzzle puzzle;
		private PictureBox[] spotPictures;
		private const int space = 35;

		private void PuzzleViewer_Resize(object sender, EventArgs e)
		{
			if (spotPictures != null)
			{
				AlignSpots();
			}
		}
	}
}
