using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {
	protected int m_x;
	protected int m_y;
	protected int m_z;
	
	protected float m_last_x;
	protected float m_last_y;
	protected float m_last_z;
	protected GameObject m_display;

	private bool m_firstUpdate = true;
	private bool m_updating = false;
	private float m_updateStart;
	private Vector3 m_from;
	private Vector3 m_to;

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

//	void Update() {
//		if(m_updating)
//		{
//			Debug.Log(ToString() + " - Updating");
////			Vector3 center = (sunrise.position + sunset.position) * 0.5F;
////			center -= new Vector3(0, 1, 0);
////			Vector3 fromVec = sunrise.position - center;
////			Vector3 toVec = sunset.position - center;
//			float fracComplete = (Time.time - m_updateStart) / GlobalScope.MOVE_TIME;
//			m_display.transform.position = Vector3.Slerp(m_from, m_to, fracComplete);
//			if(fracComplete > 1f)
//			{
//				m_updating = false;
//			}
//		}
//	}
	
	public void UpdatePosition(int x, int y, int z)
	{
		if(m_display != null)
		{
//			if(m_firstUpdate)
//			{
				m_display.transform.position = new Vector3(x, y, z);
//				m_firstUpdate = false;
//			} else {
//				m_last_x = m_display.transform.position.x;
//				m_last_y = m_display.transform.position.y;
//				m_last_z = m_display.transform.position.z;
//				
////				Vector3 fromVec;
////				Vector3 toVec;
//				Vector3 rotPoint;
//				if(!m_last_x.Equals(x))
//				{
//					m_from = new Vector3(m_last_x, 0, 0);
//					m_to = new Vector3(x, 0, 0);
//					rotPoint = new Vector3(0, m_last_y, m_last_z);
//				} 
//				else if (!m_last_y.Equals(y)) 
//				{
//					m_from = new Vector3(0, m_last_y, 0);
//					m_to = new Vector3(0, y, 0);
//					rotPoint = new Vector3(m_last_x, 0, m_last_z);
//				} 
//				else if (!m_last_z.Equals(z)) 
//				{
//					m_from = new Vector3(0, 0, m_last_z);
//					m_to = new Vector3(0, 0, z);
//					rotPoint = new Vector3(m_last_x, m_last_y, 0);
//				} 
//				else 
//				{
//					return;
//				}
//				
//				Debug.Log("FromVec: " + m_from);
//				Debug.Log("ToVec: " + m_to);
//				
////				float angle = Vector3.Angle(m_from, m_to);
////				Debug.Log("Angle: " + angle);
//				
////				m_display.transform.RotateAround(rotPoint, Vector3.Cross(m_from, m_to), angle); 
//				m_updateStart = Time.time;
//
//				Debug.Log("m_updateStart: " + m_updateStart);
//				m_updating = true;
//			}
//
//			
////			m_display.transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
//
////			m_display.transform.position = new Vector3(x, y, z);
		}
	}
}
