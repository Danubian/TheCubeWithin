using UnityEngine;
using System.Collections;

public class EmptyPiece : Piece {
	public EmptyPiece(int x, int y, int z) : base(x, y, z)
	{
		m_display = null;
	}
}
