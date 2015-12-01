using UnityEngine;
using System.Collections;

public class CenterPiece : Piece {
	public CenterPiece(int x, int y, int z) : base(x, y, z)
	{
		m_display = Instantiate(Resources.Load("Center")) as GameObject;
		UpdateDisplay();
	}
}
