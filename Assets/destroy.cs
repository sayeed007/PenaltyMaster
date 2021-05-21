using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetMouseButton (0))
			gameObject.SetActive (false);	
	}
}
