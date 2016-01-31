using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {
	public bool TimeToMove;
	public Transform floatingPosition;
	public BeaconScriptModified gameManager;
	// Use this for initialization
	Vector3 firstPosition;
	Vector3 secondPosition;
	Vector3 thirdPosition;
	public float speed;

	private bool firstPositionDone = false;
	private bool secondPositionDone = false;
	private bool thirdPositionDone = false;

	void Start () {
		firstPosition = new Vector3 (247, 5, 224);
		secondPosition = new Vector3 (255, 5, 222);
		thirdPosition = new Vector3 (255, 1, 224);

	}

	void EyeActivated () {
		TimeToMove = true;
	}

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (TimeToMove) {
			if (!firstPositionDone) {
				moveToPosition (step, firstPosition);
			} else if (!secondPositionDone) {
				moveToPosition (step, secondPosition);
			} else if (!thirdPositionDone) {
				moveToPosition (step, thirdPosition);
			}
		}
	}

	void moveToPosition (float step, Vector3 targetPosition) {
		transform.position = Vector3.MoveTowards (transform.position, targetPosition , step);
		if (transform.position == firstPosition) {
			Debug.Log ("first position done.");
			firstPositionDone = true;
		}
		if (transform.position == secondPosition) {
			Debug.Log ("second position done.");
			secondPositionDone = true;
		}
		if (transform.position == thirdPosition) {
			Debug.Log ("third position done.");
			thirdPositionDone = true;
			gameManager.isMoving = true;
		}
	}
}
