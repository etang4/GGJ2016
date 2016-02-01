using UnityEngine;
using System.Collections;

public class Level3Door1 : MonoBehaviour {

    public GameObject[] beacons;
    public float speed = 5f;
    public float RotationSpeed = 0.3f;
    public GameObject player;
    public int currentlyWalkingTo;
    public bool triggered;
    public bool doneRotating;
    public bool isWalking;

<<<<<<< HEAD
=======
    public AudioSource audioSource;
    public AudioClip dejavu;

>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
    private float threshold = 0.2f;


	// Use this for initialization
	void Start () {
        triggered = false;
        doneRotating = false;
        isWalking = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (triggered)
        {
<<<<<<< HEAD
=======
            
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
            if (!isWalking)
            {
                Vector3 targetDir = beacons[currentlyWalkingTo].transform.position - player.transform.position;
                Vector3 newDir = Vector3.RotateTowards(player.transform.forward, targetDir, RotationSpeed * Time.deltaTime, 0.0F);
                player.transform.rotation = Quaternion.LookRotation(newDir);
            }
            else
            {
<<<<<<< HEAD
                if(Vector3.Distance(beacons[currentlyWalkingTo].transform.position, player.transform.position) < threshold)
=======
                
                if (Vector3.Distance(player.transform.position, beacons[currentlyWalkingTo].transform.position) < threshold)
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
                {
                    isWalking = false;
                    currentlyWalkingTo++;
                    if(currentlyWalkingTo >= beacons.Length)
                    {
                        triggered = false;
<<<<<<< HEAD
=======
                        //Audio Here
                        //LoadLevel
                        StartCoroutine("FadeOut");
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
                    }
                }
                else
                {
<<<<<<< HEAD
                    Vector3.MoveTowards(player.transform.position, beacons[currentlyWalkingTo].transform.position, speed * Time.deltaTime);
=======
                    player.transform.position = Vector3.MoveTowards(player.transform.position, beacons[currentlyWalkingTo].transform.position, speed * Time.deltaTime);
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
                }
            }
            //check if rotation has stopped
            if (player.GetComponent<Rigidbody>().angularVelocity == Vector3.zero)
            {
                isWalking = true;  
            }
        }
	}

    void EyeActivated()
    {
        triggered = true;
<<<<<<< HEAD
=======
        audioSource.clip = dejavu;
        audioSource.Play();
    }

    IEnumerator FadeOut()
    {
        float fadeTime = GameObject.Find("Player").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(4);
        Debug.Log("Faded Out");
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
    }
}
