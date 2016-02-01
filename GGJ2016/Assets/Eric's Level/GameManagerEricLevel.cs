using UnityEngine;
using System.Collections;

public class GameManagerEricLevel : MonoBehaviour {

    public GameObject[] customBeacons;
    public GameObject waterGOB;
    public int currentBeacon;
    public bool doneUsingCustomWaypoints;
    public bool completedCurrentTask;
    public float[] speed;

<<<<<<< HEAD
=======
    public AudioSource audioSource;
    public AudioClip introClip;
    public AudioClip lookForPattern;
    public AudioClip rightFish;
    public AudioClip rightDoorClip;
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
    Transform playerT;
    float threshold = 0.05f;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        currentBeacon = 0;
        completedCurrentTask = false;
=======
        audioSource.clip = introClip;
        audioSource.Play();
        currentBeacon = 0;
        completedCurrentTask = true;
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
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
<<<<<<< HEAD
                currentBeacon++;
                if(currentBeacon == 1)
                {
=======
                
                currentBeacon++;
                if(currentBeacon == 1)
                {
                    audioSource.clip = lookForPattern;
                    audioSource.Play();
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
                    Destroy(waterGOB);
                }
                if(currentBeacon >= customBeacons.Length)
                {
                    doneUsingCustomWaypoints = true;
<<<<<<< HEAD
=======
                    audioSource.clip = rightDoorClip;
                    audioSource.Play();
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
                }
            }
        }
	}
<<<<<<< HEAD
=======

    void EyeActivated()
    {
        completedCurrentTask = true;
        audioSource.clip = rightFish;
        audioSource.Play();
        if(currentBeacon == 1)
        {
            
        }
    }
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
}
