// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
public class Cube
{
	private Color[] m_model = new Color[108];
	private int[] equatorIndices = new int[12]{48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59};
	private int[] middleIndices = new int[12]{100, 88, 76, 64, 52, 40, 28, 16, 4, 46, 58, 70};
	private int[] standingIndices = new int[12]{89, 88, 87, 61, 49, 37, 15, 16, 17, 43, 55, 67};

	public Cube ()
	{
		Initialize();
		Color c = GetColorAtIndex(Face.FRONT, 1, 1);
		Debug.Log("Color At Front point 1, 1 : " + c);
		IsCubeComplete();
		RotateMidLayer(MidLayer.EQUATOR, true);
		c = GetColorAtIndex(Face.FRONT, 1, 1);
		Debug.Log("Color At Front point 1, 1 : " + c);
		IsCubeComplete();
		RotateMidLayer(MidLayer.EQUATOR, false);
		c = GetColorAtIndex(Face.FRONT, 1, 1);
		Debug.Log("Color At Front point 1, 1 : " + c);
		IsCubeComplete();
		RotateMidLayer(MidLayer.MIDDLE, true);
		c = GetColorAtIndex(Face.FRONT, 1, 1);
		Debug.Log("Color At Front point 1, 1 : " + c);
		IsCubeComplete();
		RotateMidLayer(MidLayer.MIDDLE, false);
		c = GetColorAtIndex(Face.FRONT, 1, 1);
		Debug.Log("Color At Front point 1, 1 : " + c);
		IsCubeComplete();
		RotateMidLayer(MidLayer.STANDING, true);
		c = GetColorAtIndex(Face.FRONT, 1, 1);
		Debug.Log("Color At Front point 1, 1 : " + c);
		IsCubeComplete();
		RotateMidLayer(MidLayer.STANDING, false);
		c = GetColorAtIndex(Face.FRONT, 1, 1);
		Debug.Log("Color At Front point 1, 1 : " + c);
		IsCubeComplete();
	}

	//Uses righthand rule
	public void RotateMidLayer(MidLayer midLayer, bool clockwise)
	{
		int[] indices;
		switch(midLayer)
		{
		case MidLayer.EQUATOR:
			indices = equatorIndices;
			break;
		case MidLayer.MIDDLE:
			indices = middleIndices;
			break;
		case MidLayer.STANDING:
			indices = standingIndices;
			break;
		default:
			indices = null;
			break;
		}

		Color[] layer = new Color[12];
		for (int i = 0; i < 12; i++)
		{
			int index = indices[i];
			layer[i] = m_model[index];
		}
		
		if(clockwise)
		{
			layer = shiftRight(layer);
		} else {
			layer = shiftLeft(layer);
		}
		
		
		for (int i = 0; i < 12; i++)
		{
			int index = indices[i];
			m_model[index] = layer[i];
		}
	}

	private Color[] shiftLeft(Color[] input) {
		Color[] result = new Color[input.Length];
		int index = 0;
		for (int i = 0; i < input.Length; i++) {
			result[index] = input[(i + 3)%(input.Length)];
			index++;
		}
		return result;
	}

	private Color[] shiftRight(Color[] input) {
		Color[] result = new Color[input.Length];
		int index = 0;
		for (int i = 0; i < input.Length; i++) {
			result[index] = input[(input.Length + i - 3)%(input.Length)];
			index++;
		}
		return result;
	}

	public void Initialize()
	{
		//Set Red Face
		InitFaceColor(Face.FRONT, Color.RED);
		InitFaceColor(Face.BACK, Color.ORANGE);
		InitFaceColor(Face.UP, Color.WHITE);
		InitFaceColor(Face.DOWN, Color.YELLOW);
		InitFaceColor(Face.LEFT, Color.GREEN);
		InitFaceColor(Face.RIGHT, Color.BLUE);
	}

	public bool IsCubeComplete()
	{
		bool result = true;
		result &= IsFaceComplete(Face.FRONT);
		result &= IsFaceComplete(Face.BACK);
		result &= IsFaceComplete(Face.UP);
		result &= IsFaceComplete(Face.DOWN);
		result &= IsFaceComplete(Face.LEFT);
		result &= IsFaceComplete(Face.RIGHT);

		Debug.Log("Is cube complete? " + result);
		return result;
	}

	private bool IsFaceComplete(Face face)
	{
		int faceIndex = (int)face;
		int x = (faceIndex % 4) * 3;
		int y = (faceIndex / 4) * 3;
		Color faceColor = Color.NONE;
		
		for (int i = x; i < x + 3; i++)
		{
			for (int j = y; j < y + 3; j++)
			{
				int index;
				IndexIntoModel(out index, i, j);
				Color indexColor = m_model[index];

				if(faceColor.Equals(Color.NONE))
				{
					faceColor = indexColor;
				} else if (!faceColor.Equals(indexColor)){
					return false;
				}
			}
		}
		return true;
	}

	private void InitFaceColor(Face face, Color initColor)
	{
		int faceIndex = (int)face;
		int x = (faceIndex % 4) * 3;
		int y = (faceIndex / 4) * 3;

		for (int i = x; i < x + 3; i++)
		{
			for (int j = y; j < y + 3; j++)
			{
				int index;
				IndexIntoModel(out index, i, j);
				m_model[index] = initColor;
			}
		}
	}
	
	private void IndexIntoModel(out int i, int x, int y)
	{
		i = x + y * 12;
	}
	
	private void IndexOutOfModel(int i, out int x, out int y)
	{
		x = i / 12;
		y = i % 12;
	}

	public Color GetColorAtIndex(Face face, int x, int y)
	{
		int faceIndex = (int)face;
		x += (faceIndex % 4) * 3;
		y += (faceIndex / 4) * 3;
		
		int index;
		IndexIntoModel(out index, x, y);
		return m_model[index];
	}

	public enum Color
	{
		RED,
		ORANGE,
		YELLOW,
		WHITE,
		GREEN,
		BLUE,
		NONE
	}

	public enum Face
	{
		UP = 9,
		DOWN = 1,
		FRONT = 5,
		BACK = 7,
		LEFT = 4,
		RIGHT = 6
	}

	public enum MidLayer
	{
		MIDDLE,  //Between Left and Right
		EQUATOR, //Between Up and Down
		STANDING //Between Front and Back
	}
}
