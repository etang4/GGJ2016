using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float RotxSpeed;
    public float RotySpeed;
    public float RotzSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    this.gameObject.transform.Rotate(RotxSpeed*Time.deltaTime, RotySpeed * Time.deltaTime, RotzSpeed * Time.deltaTime);
	}
}
