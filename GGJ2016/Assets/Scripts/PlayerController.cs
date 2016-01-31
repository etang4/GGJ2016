using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public float rotationSpeed;
    public int numOfWaypoints;
    public int curWaypoint;
    public Vector3 target;

	public Vector3 target1;
	public int numOfWaypoints1;
	public int curWaypoint1;
    public Vector3 moveDirection;
    public Vector3 Velocity;
    public BeaconScriptModified checker;
    
    public GameObject[] Beacons;
	public GameObject[] Beacons1;
	bool firstSection = true;
    // Use this for initialization
    void Start()
    {
        curWaypoint = 0;
		curWaypoint1 = 0;
        checker = FindObjectOfType<BeaconScriptModified>();
    }

    // Update is called once per frame
    void Update()
    {
		if (firstSection) {
			if (checker.getIsMoving () == true && curWaypoint < numOfWaypoints) {
				target = Beacons [curWaypoint].transform.position;

				if (checker.getIsFacing () == true) {
					moveDirection = target - transform.position;
					if (moveDirection.magnitude < 1) {
						checker.setisFacingToFalse ();
						curWaypoint++;
						Velocity = Vector3.zero;
					} else {
						Velocity = GetComponent<Rigidbody> ().velocity;
						Velocity = moveDirection.normalized * Speed;
					}
				} else {
					float facingValue = Vector3.Dot (this.transform.forward, (target - transform.position).normalized);
					if (facingValue > 0.99) {
						checker.setisFacingToTrue ();
					} else {
						transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target - transform.position), rotationSpeed * Time.deltaTime);
					}
				}

			} else if (curWaypoint >= numOfWaypoints) {
				checker.setisMovingToFalse ();
				Velocity = Vector3.zero;
				firstSection = false;
			}

			GetComponent<Rigidbody> ().velocity = Velocity;
		} else {
			if (checker.getIsMoving () == true && curWaypoint1 < numOfWaypoints1) {
				target1 = Beacons1 [curWaypoint1].transform.position;

				if (checker.getIsFacing () == true) {
					moveDirection = target1 - transform.position;
					if (moveDirection.magnitude < 1) {
						checker.setisFacingToFalse ();
						curWaypoint1++;
						Velocity = Vector3.zero;
					} else {
						Velocity = GetComponent<Rigidbody> ().velocity;
						Velocity = moveDirection.normalized * Speed;
					}
				} else {
					float facingValue = Vector3.Dot (this.transform.forward, (target1 - transform.position).normalized);
					if (facingValue > 0.99) {
						checker.setisFacingToTrue ();
					} else {
						transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target1 - transform.position), rotationSpeed * Time.deltaTime);
					}
				}

			} 
			else if (curWaypoint1 >= numOfWaypoints1) 
			{
				checker.setisMovingToFalse ();
				Velocity = Vector3.zero;
			}

			GetComponent<Rigidbody>().velocity = Velocity ;
		}

        
    }
   
}
