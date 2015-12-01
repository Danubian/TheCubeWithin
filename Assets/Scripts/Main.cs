using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	Cube2 cube;

	// Use this for initialization
	void Start () {
		cube = new Cube2();
		StartCoroutine(cube.Scramble(1000));
	}
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Vertical"))
		{
			bool isPos = Input.GetAxis("Vertical") > 0f;
			Debug.Log("Triggered: " + Input.GetAxis("Vertical") + ", " + isPos);
			cube.RotateLayer(Face.X, 1, isPos);
		}

		if(Input.GetButtonDown("Horizontal"))
		{
			bool isPos = Input.GetAxis("Horizontal") > 0f;
			Debug.Log("Triggered: " + Input.GetAxis("Horizontal") + ", " + isPos);
			cube.RotateLayer(Face.Y, 1, isPos);
		}
	}
}
