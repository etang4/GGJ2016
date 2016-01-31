using UnityEngine;
using System.Collections;

public class ColorGame : MonoBehaviour {

    public GameObject Red;
    public GameObject Blue;
    public GameObject Yellow;
    public GameObject Red2;
    public GameObject Blue2;
    public GameObject Yellow2;
    public bool isRedSeen;
    public bool isBlueSeen;
    public bool isYellowSeen;
    public bool is2ndRedSeen;
    public bool is2ndBlueSeen;
    public bool is2ndYellowSeen;
    public bool start2ndGroup;

	// Use this for initialization
	void Start () 
    {

        isRedSeen = false;
        isBlueSeen = false;
        isYellowSeen = false;
        is2ndRedSeen = false;
        is2ndBlueSeen = false;
        is2ndYellowSeen = false;
        start2ndGroup = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isRedSeen == true && (isBlueSeen == false || isYellowSeen == false))
        {
            Destroy(Red);
        }
        if (isBlueSeen == true && (isRedSeen == false || isYellowSeen == false))
        {
            Destroy(Blue);
        }
        if (isYellowSeen == true && (isBlueSeen == false || isRedSeen == true))
        {
            Destroy(Yellow);
        }
        if (isRedSeen == true && isBlueSeen == true && isYellowSeen == true)
        {
            start2ndGroup = true;
        }
        if (start2ndGroup == true && Red2 != null)
        {
            Red2.GetComponent<EnemyController>().setTimeToMoveTrue();
        } 
        if ((is2ndRedSeen == true && Red2 != null) && start2ndGroup == true)
        {
            Red2.GetComponent<EnemyController>().DestroyObject();
            Blue2.GetComponent<EnemyController>().setTimeToMoveTrue();
        }
        if ((is2ndBlueSeen == true && Blue2 != null) && start2ndGroup == true)
        {
            Blue2.GetComponent<EnemyController>().DestroyObject();
            Yellow2.GetComponent<EnemyController>().setTimeToMoveTrue();
        }
        if ((is2ndYellowSeen == true && Yellow2 != null) && start2ndGroup == true)
        {
            Yellow2.GetComponent<EnemyController>().DestroyObject();
        }
	}
}
