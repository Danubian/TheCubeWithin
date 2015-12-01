using UnityEngine;
using System.Collections;

public class CornerPiece : Piece {
	public CornerPiece(int x, int y, int z) : base(x, y, z)
	{
		m_display = Instantiate(Resources.Load("Corner")) as GameObject;
		UpdateDisplay();
	}
}
