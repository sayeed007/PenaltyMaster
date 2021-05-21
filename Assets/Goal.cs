using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	private int goal;
	void Start () {
		goal = 0;
	}
	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "Ball") {
			goal++;
		}
	}
	void OnGUI()
	{
		GUI.Box (new Rect (50,50, 300, 100), "GOAL " + goal);
	}
}
