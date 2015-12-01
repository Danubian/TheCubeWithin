using UnityEngine;
using System.Collections;

public class EdgePiece : Piece {
	public EdgePiece(int x, int y, int z) : base(x, y, z)
	{
		m_display = Instantiate(Resources.Load("Edge")) as GameObject;
		UpdateDisplay();
	}
}
