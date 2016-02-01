using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public float rotationSpeed;
	public Vector3 moveDirection;
	public Vector3 Velocity;
	public BeaconScriptModified checker;

    public int numOfWaypoints;
    public int curWaypoint;
    public Vector3 target;
	public GameObject[] Beacons;

	public int numOfWaypoints1;
	public int curWaypoint1;
	public Vector3 target1;
	public GameObject[] Beacons1;

	public int numOfWaypoints2;
	public int curWaypoint2;
	public Vector3 target2;
	public GameObject[] Beacons2;
    
	public AudioSource audioSource;
	public AudioClip firstMovementDone;
	public AudioClip secondMovementDone;
	public AudioClip finalMovementStarted;

	bool firstSection = true;
	bool secondSection = true;
    // Use this for initialization
    void Start()
    {
        curWaypoint = 0;
		curWaypoint1 = 0;
		curWaypoint2 = 0;
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
				audioSource.clip = firstMovementDone;
				audioSource.Play ();
			}

			GetComponent<Rigidbody> ().velocity = Velocity;
		}else if (secondSection) {
			if (checker.getIsMoving () == true && curWaypoint2 < numOfWaypoints2) {
				target2 = Beacons2 [curWaypoint2].transform.position;

				if (checker.getIsFacing () == true) {
					moveDirection = target2 - transform.position;
					if (moveDirection.magnitude < 1) {
						checker.setisFacingToFalse ();
						curWaypoint2++;
						Velocity = Vector3.zero;
					} else {
						Velocity = GetComponent<Rigidbody> ().velocity;
						Velocity = moveDirection.normalized * Speed;
					}
				} else {
					float facingValue = Vector3.Dot (this.transform.forward, (target2- transform.position).normalized);
					if (facingValue > 0.99) {
						checker.setisFacingToTrue ();
					} else {
						transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target2 - transform.position), rotationSpeed * Time.deltaTime);
					}
				}

			} else if (curWaypoint2 >= numOfWaypoints2) {
				checker.setisMovingToFalse ();
				Velocity = Vector3.zero;
				secondSection = false;
                playSecondSound();
			}

			GetComponent<Rigidbody> ().velocity = Velocity;
		}
		else {
			playLeavingSound ();
            
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
                StartCoroutine("FadeOut");
                checker.setisMovingToFalse ();
				Velocity = Vector3.zero;
                playLeavingSound();
			}

			GetComponent<Rigidbody>().velocity = Velocity ;
		}

        
    }

    bool alreadyPlayed = false;
    void playSecondSound() {
        if (!alreadyPlayed) {
            audioSource.clip = secondMovementDone;
            audioSource.Play();
            alreadyPlayed = true;
        }
        
    }

    bool alreadyPlayed1 = false;
	void playLeavingSound () {
        if (!alreadyPlayed1) {
            audioSource.clip = finalMovementStarted;
            audioSource.Play();
            alreadyPlayed1 = true;
        }
	}
    IEnumerator FadeOut()
    {
        float fadeTime = GameObject.Find("GameManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(4);
        Debug.Log("Faded Out");
    }

}
