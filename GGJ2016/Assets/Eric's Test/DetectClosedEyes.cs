using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UserPresenceComponent))]
public class DetectClosedEyes : MonoBehaviour {

    public float startTime;
    public float waitTime = 2f;
    public bool eyesClosed;
    public bool canProceed;
    public bool finalClip;

    public AudioSource audioSource;
    public AudioClip introClip;
    public AudioClip closedEyes;
    public AudioClip proceedClip;
	// Use this for initialization
	void Start () {
        eyesClosed = false;
        finalClip = false;
        canProceed = false;
        audioSource.clip = introClip;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (!canProceed)
        {
            if (!this.gameObject.GetComponent<UserPresenceComponent>().IsUserPresent)
            {
                if (!eyesClosed)
                {
                    startTime = Time.time;
                    eyesClosed = true;
                }
                else
                {
                    if (Time.time > startTime + waitTime)
                    {
                        //Begin Audio Here
                        audioSource.clip = closedEyes;
                        audioSource.Play();
                        canProceed = true;
                    }
                }
            }
            else
            {
                eyesClosed = false;
            }
        }
        if (canProceed && !finalClip)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = proceedClip;
                audioSource.Play();
                finalClip = true;
            }
                

        }
        if (finalClip)
        {
            if (!audioSource.isPlaying)
            {
                Application.LoadLevel(2);
            }
        }
    }
}
