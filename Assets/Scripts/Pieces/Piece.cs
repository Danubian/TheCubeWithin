using UnityEngine;
using System.Collections;

public class Piece : ScriptableObject {
	protected int m_x;
	protected int m_y;
	protected int m_z;
	protected GameObject m_display;

	public Piece (int x, int y, int z)
	{
		m_x = x;
		m_y = y;
		m_z = z;
	}

	public override string ToString()
	{
		return "" + (m_x + 1 + ((m_y + 1) * GlobalScope.CUBE_SIZE) + ((m_z + 1) * GlobalScope.CUBE_SIZE^2));
	}

	protected void UpdateDisplay()
	{
		UpdatePosition(m_x, m_y, m_z);
		if(m_display != null)
		{
			m_display.GetComponent<MeshRenderer>().material.color = 
				//			Color.red;
				new Color(
					(m_x - GlobalScope.CUBE_OFFSET) * 1f / (GlobalScope.CUBE_SIZE - 1),
					(m_y - GlobalScope.CUBE_OFFSET) * 1f / (GlobalScope.CUBE_SIZE - 1),
					(m_z - GlobalScope.CUBE_OFFSET) * 1f / (GlobalScope.CUBE_SIZE - 1));
		}
	}

	public void UpdatePosition(int x, int y, int z)
	{
		if(m_display != null)
		{
			m_display.transform.position = new Vector3(x, y, z);
		}
	}
}
