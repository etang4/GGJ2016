using UnityEngine;
using System.Collections;

public class GameManagerEricLevel : MonoBehaviour {

    public GameObject[] customBeacons;
    public GameObject waterGOB;
    public int currentBeacon;
    public bool doneUsingCustomWaypoints;
    public bool completedCurrentTask;
    public float[] speed;

    public AudioSource audioSource;
    public AudioClip introClip;
    public AudioClip lookForPattern;
    public AudioClip rightFish;
    public AudioClip rightDoorClip;
    Transform playerT;
    float threshold = 0.05f;

	// Use this for initialization
	void Start () {
        audioSource.clip = introClip;
        audioSource.Play();
        currentBeacon = 0;
        completedCurrentTask = true;
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
                    audioSource.clip = lookForPattern;
                    audioSource.Play();
                    Destroy(waterGOB);
                }
                if(currentBeacon >= customBeacons.Length)
                {
                    doneUsingCustomWaypoints = true;
                    audioSource.clip = rightDoorClip;
                    audioSource.Play();
                }
            }
        }
	}

    void EyeActivated()
    {
        completedCurrentTask = true;
        audioSource.clip = rightFish;
        audioSource.Play();
        if(currentBeacon == 1)
        {
            
        }
    }
}
