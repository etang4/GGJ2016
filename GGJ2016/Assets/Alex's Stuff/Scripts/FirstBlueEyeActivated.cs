using UnityEngine;
using System.Collections;

public class FirstBlueEyeActivated : MonoBehaviour {

    public ColorGame checker;
    // Use this for initialization
    void Start()
    {
        checker = FindObjectOfType<ColorGame>();
    }

    // Update is called once per frame
    void EyeActivated()
    {
        checker.isBlueSeen = true;
    }
}
