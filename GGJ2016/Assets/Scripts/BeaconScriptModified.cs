using UnityEngine;
using System.Collections;

public class BeaconScriptModified : MonoBehaviour {

    public bool isFacing;
    public bool isMoving;

        // Use this for initialization
	void Start () {
        isFacing = false;
        isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	void EyeActivated () {
		isMoving = true;
	}

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
