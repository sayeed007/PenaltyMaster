using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public GameObject ball;
	private int num;
	private Vector3 origin;
	private int goal = 0;
	private int point = 0;
	private float speed = 500;
	private Rigidbody rb;

	void Start()
	{
		origin = new Vector3 (0.0f, 0.25f, 5.5f);
		rb = GetComponent<Rigidbody> ();
		num = 0;
	}
	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Mouse X");
		float vertical = Input.GetAxis ("Mouse Y");

		transform.Rotate (-5 * vertical, 2 * horizontal, 0f);
		if (Input.GetMouseButtonDown (0)) {
			rb.AddForce (transform.forward * speed);
			speed = 0;
			num++;
			if (num >= 6) {
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{		
		if (col.gameObject.tag == "Red")
		{
			point += 200;
		}
		if (col.gameObject.tag == "Goal") {
			goal++;
			point += 100;
			rb.velocity = Vector3.zero;
			transform.position = origin;
			speed = 500;
		}
		if (col.gameObject.tag == "Finish")
		{
			rb.velocity = Vector3.zero;
			transform.position = origin;
			speed = 500;
		}
	}
		
	void OnGUI()
	{
		if (num < 5) {
			GUI.Box (new Rect (10, 10, 150, 60), "SHOOT  " + num + "\nGOAL  " + goal + "\nPOINT  " + point);
		}
		else {
			GUI.Box (new Rect (Screen.width/2-100, Screen.height/2 - 50, 200, 100), "FINAL SCORE"+"\nSHOOT  "+num+"\nGOAL  " + goal+"\nPOINT  " + point);
		}
	}
}