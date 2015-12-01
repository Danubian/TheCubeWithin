using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class Cube2 : MonoBehaviour{

	private static int CUBE_SIZE = GlobalScope.CUBE_SIZE;
	private static int CUBE_OFFSET = GlobalScope.CUBE_OFFSET;
	private Piece[,,] m_cube = new Piece[CUBE_SIZE,CUBE_SIZE,CUBE_SIZE];


	/**
	 *  15 16  17
	 * /  /  / 14
	 * 6 7 8 / 11
	 * 3 4 5 /
	 * 0 1 2
	 * 
	 */


	public Cube2()
	{
		Initialize();
//		RotateLayer(Face.X, 0);
	}

	void Initialize()
	{
		for(int x = 0; x < CUBE_SIZE; x++)
		{
			for(int y = 0; y < CUBE_SIZE; y++)
			{
				for(int z = 0; z < CUBE_SIZE; z++)
				{
					bool isXEdge = x == 0 || x == CUBE_SIZE - 1;
					bool isYEdge = y == 0 || y == CUBE_SIZE - 1;
					bool isZEdge = z == 0 || z == CUBE_SIZE - 1;

					int edgeSum = CountTrue(isXEdge, isYEdge, isZEdge);

					switch (edgeSum)
					{
					case 0:
						m_cube[x,y,z] = new EmptyPiece(x + CUBE_OFFSET, y + CUBE_OFFSET, z + CUBE_OFFSET);
						break;
					case 1:
						m_cube[x,y,z] = new CenterPiece(x + CUBE_OFFSET, y + CUBE_OFFSET, z + CUBE_OFFSET);
						break;
					case 2:
						m_cube[x,y,z] = new EdgePiece(x + CUBE_OFFSET, y + CUBE_OFFSET, z + CUBE_OFFSET);
						break;
					case 3:
						m_cube[x,y,z] = new CornerPiece(x + CUBE_OFFSET, y + CUBE_OFFSET, z + CUBE_OFFSET);
						break;
					}
				}
			}
		}
	}

	public void RotateLayer(Face face, int layerIndex, bool forward){
		int faceIndex = (int)face;
		
		Piece[,] oldMatrix = new Piece[CUBE_SIZE, CUBE_SIZE];
		Piece[,] newMatrix = new Piece[CUBE_SIZE, CUBE_SIZE];

		//Get Layer
		switch (face)
		{
		case Face.X:
			for(int y = 0; y < CUBE_SIZE; y++)
			{
				for(int z = 0; z < CUBE_SIZE; z++)
				{
					oldMatrix[y,z] = m_cube[layerIndex,y,z]; 
				}
			}
			//[layer, XXX, XXX]
			break;
		case Face.Y:
			for(int x = 0; x < CUBE_SIZE; x++)
			{
				for(int z = 0; z < CUBE_SIZE; z++)
				{
					oldMatrix[x,z] = m_cube[x,layerIndex,z]; 
				}
			}
			//[XXX, layer, XXX]
			break;
		case Face.Z:
			for(int x = 0; x < CUBE_SIZE; x++)
			{
				for(int y = 0; y < CUBE_SIZE; y++)
				{
					oldMatrix[x,y] = m_cube[x,y,layerIndex]; 
				}
			}
			//[XXX, XXX, layer]
			break;
		}

		//Rotate layer
		if(forward)
		{
			int newColumn, newRow = 0;
			for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
			{
				newColumn = 0;
				for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
				{
					newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
					newColumn++;
				}
				newRow++;
			}
		} else {
			int newColumn, newRow = 0;
			for (int oldColumn = 0; oldColumn < oldMatrix.GetLength(1); oldColumn++)
			{
				newColumn = 0;
				for (int oldRow = oldMatrix.GetLength(0) - 1; oldRow >= 0; oldRow--)
				{
					newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
					newColumn++;
				}
				newRow++;
			}
		}
		
//		Print2DArray(oldMatrix);
//		Print2DArray(newMatrix);

		//Update layer
		switch (face)
		{
		case Face.X:
			for(int y = 0; y < CUBE_SIZE; y++)
			{
				for(int z = 0; z < CUBE_SIZE; z++)
				{
					Piece piece = newMatrix[y,z];
					piece.UpdatePosition(layerIndex + CUBE_OFFSET, y + CUBE_OFFSET, z + CUBE_OFFSET);
					m_cube[layerIndex,y,z] = piece; 
				}
			}
			//[layer, XXX, XXX]
			break;
		case Face.Y:
			for(int x = 0; x < CUBE_SIZE; x++)
			{
				for(int z = 0; z < CUBE_SIZE; z++)
				{
					
					Piece piece = newMatrix[x,z];
					piece.UpdatePosition(x + CUBE_OFFSET, layerIndex + CUBE_OFFSET, z + CUBE_OFFSET);
					m_cube[x,layerIndex,z] = piece;
				}
			}
			//[XXX, layer, XXX]
			break;
		case Face.Z:
			for(int x = 0; x < CUBE_SIZE; x++)
			{
				for(int y = 0; y < CUBE_SIZE; y++)
				{
					Piece piece = oldMatrix[x,y];
					piece.UpdatePosition(x + CUBE_OFFSET, y + CUBE_OFFSET, layerIndex + CUBE_OFFSET);
					m_cube[x,y,layerIndex] = piece;
				}
			}
			//[XXX, XXX, layer]
			break;
		}
	}
	
	//Returns a count of the number of true arguments
	public static int CountTrue(params bool[] args)
	{
		return args.Count(t => t);
	}

	public static void Print2DArray(Piece[,] arr)
	{
		int rowLength = arr.GetLength(0);
		int colLength = arr.GetLength(1);
		
		for (int i = 0; i < rowLength; i++)
		{
			string line = "";
			for (int j = 0; j < colLength; j++)
			{
				line += string.Format("{0} ", arr[i, j]);
			}
			Debug.Log(line);
		}
	}
}

public enum Face {
	X = 0,
	Y = 1,
	Z = 2
}
