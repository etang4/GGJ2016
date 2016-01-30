using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Transform startingPoint;
	public Transform stoppingPoint;
	public float speed;
	bool OpenDoor = false;

	void Update () {
		float step = speed * Time.deltaTime;
		if (OpenDoor) {
			transform.position = Vector3.MoveTowards (transform.position, stoppingPoint.position, step);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, startingPoint.position, step);
		}
	}

	/// <summary>
	/// Slides the door open.
	/// </summary>
	void Open () {
		OpenDoor = true;
	}

	/// <summary>
	/// Slides the door closes.
	/// </summary>
	void Close () {
		OpenDoor = false;
	}

	void TurnOffLights (){
	
	}
}
