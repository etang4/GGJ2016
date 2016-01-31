using UnityEngine;
using System.Collections;

public class Level3Door3 : MonoBehaviour {

    public GameObject[] beacons;
    public float speed = 5f;
    public float RotationSpeed = 0.3f;
    public GameObject player;
    public int currentlyWalkingTo;
    public bool triggered;
    public bool doneRotating;
    public bool isWalking;

    private float threshold = 0.2f;

    // Use this for initialization
    void Start()
    {
        triggered = false;
        doneRotating = false;
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            if (!isWalking)
            {
                Vector3 targetDir = beacons[currentlyWalkingTo].transform.position - player.transform.position;
                Vector3 newDir = Vector3.RotateTowards(player.transform.forward, targetDir, RotationSpeed * Time.deltaTime, 0.0F);
                player.transform.rotation = Quaternion.LookRotation(newDir);
            }
            else
            {

                if (Vector3.Distance(player.transform.position, beacons[currentlyWalkingTo].transform.position) < threshold)
                {
                    isWalking = false;
                    currentlyWalkingTo++;
                    if (currentlyWalkingTo >= beacons.Length)
                    {
                        triggered = false;
                        player.GetComponent<PlayerControllerEric>().enabled = true;
                    }
                }
                else
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, beacons[currentlyWalkingTo].transform.position, speed * Time.deltaTime);
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
    }
}
