using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float Speed;
    public float rotationSpeed;
    public float waitTime;
    public int numOfWaypoints;
    public int curWaypoint;
    public bool timeTomove;
    public bool timeToExit;
    public Vector3 target;
    public Vector3 moveDirection;
    public Vector3 Velocity;
    
    public GameObject[] Beacons;

	// Use this for initialization
	void Start () {
        curWaypoint = 0;
        timeTomove = false;
        timeToExit = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timeTomove == true && curWaypoint < numOfWaypoints)
        {
            target = Beacons[curWaypoint].transform.position;
                moveDirection = target - transform.position;
                if (moveDirection.magnitude < 1)
                {
                    curWaypoint++;
                }
                
                Velocity = GetComponent<Rigidbody>().velocity;
                Velocity = moveDirection.normalized * Speed;
                GetComponent<Rigidbody>().velocity = Velocity;
         }
        else if (timeTomove == true && (curWaypoint >= numOfWaypoints)) 
        {
            timeTomove = false;
            timeToExit = true;
            Velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Velocity;
        }
        else if (timeToExit == true) 
        {
            StartCoroutine("FadeOut");
        }
            
    }
    public void setTimeToMoveTrue() 
    {
        timeTomove = true;
    }

    public void DestroyObject() 
    {
        Destroy(this.gameObject);
    }
    IEnumerator FadeOut() 
    {
        float fadeTime = GameObject.Find("GM").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Debug.Log("Faded Out");
    }
       
}

