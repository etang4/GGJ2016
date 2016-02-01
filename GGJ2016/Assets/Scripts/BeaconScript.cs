using UnityEngine;
using System.Collections;

public class BeaconScript : MonoBehaviour {

    public bool isFacing;
    public bool isMoving;
<<<<<<< HEAD
	
        // Use this for initialization
	void Start () {
        isFacing = false;
        isMoving = false;
=======

        // Use this for initialization
	void Start () {
        isFacing = false;
        isMoving = true;
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

<<<<<<< HEAD
=======
	void EyeActivated () {
		isMoving = true;
	}

>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
    public bool getIsFacing() 
    {
        return isFacing;
    }

    public bool getIsMoving()
    {
        return isMoving;
    }

    public void setisFacingToTrue()
    {
        isFacing = true;
    }

    public void setisFacingToFalse()
    {
        isFacing = false;
    }

    public void setisMovingTrue()
    {
        isMoving = true;
    }

    public void setisMovingToFalse()
    {
        isMoving = false;
    }


}
