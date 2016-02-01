using UnityEngine;
using System.Collections;

public class PlayerControllerEric : MonoBehaviour {

    public float Speed;
    public float rotationSpeed;
    public int numOfWaypoints;
    public int curWaypoint;
    public Vector3 target;
    public Vector3 moveDirection;
    public Vector3 Velocity;
    public BeaconScript checker;
    
    public GameObject[] Beacons;

    public AudioSource audioSource;
    public AudioClip weirdHouse;
    bool alreadyPlayed3 = false;
    // Use this for initialization
    void Start()
    {
        curWaypoint = 0;
        checker = FindObjectOfType<BeaconScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checker.getIsMoving() == true && curWaypoint < numOfWaypoints) 
        {
            target = Beacons[curWaypoint].transform.position;
            if (checker.getIsFacing() == true)
            {
                moveDirection = target - transform.position;
                if (moveDirection.magnitude < 1)
                {
                    checker.setisFacingToFalse();
                    curWaypoint++;
                    Velocity = Vector3.zero;
                }
                else
                {
                    Velocity = GetComponent<Rigidbody>().velocity;
                    Velocity = moveDirection.normalized * Speed;
                }
            }
            else
            {
                float facingValue = Vector3.Dot(this.transform.forward, (target - transform.position).normalized);
                if (facingValue > 0.99)
                {
                    checker.setisFacingToTrue();
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), rotationSpeed * Time.deltaTime);
                }
            }

        }

        else if (curWaypoint >= numOfWaypoints)
        {
            checker.setisMovingToFalse();
            Velocity = Vector3.zero;
            if (!alreadyPlayed3) {
                audioSource.clip = weirdHouse;
                audioSource.Play();
                alreadyPlayed3 = true;
            }
        }

        GetComponent<Rigidbody>().velocity = Velocity ;
        
    }
   
}
