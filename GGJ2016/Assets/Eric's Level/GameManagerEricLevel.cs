using UnityEngine;
using System.Collections;

public class GameManagerEricLevel : MonoBehaviour {

    public GameObject[] customBeacons;
    public GameObject waterGOB;
    public int currentBeacon;
    public bool doneUsingCustomWaypoints;
    public bool completedCurrentTask;
    public float[] speed;

    Transform playerT;
    float threshold = 0.05f;

	// Use this for initialization
	void Start () {
        currentBeacon = 0;
        completedCurrentTask = false;
        doneUsingCustomWaypoints = false;
        playerT = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (!doneUsingCustomWaypoints && completedCurrentTask)
        {
            playerT.position = Vector3.MoveTowards(playerT.position, customBeacons[currentBeacon].transform.position, speed[currentBeacon]*Time.deltaTime);
            if(Vector3.Distance(playerT.position, customBeacons[currentBeacon].transform.position) < threshold)
            {
                completedCurrentTask = false;
                currentBeacon++;
                if(currentBeacon == 1)
                {
                    Destroy(waterGOB);
                }
                if(currentBeacon >= customBeacons.Length)
                {
                    doneUsingCustomWaypoints = true;
                }
            }
        }
	}
}
