using UnityEngine;
using System.Collections;

public class WindowTrigger : MonoBehaviour {
    public GameObject House;
    public bool triggered;

	// Use this for initialization
	void Start () {
        triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            explode();
            triggered = false;
        }
	}

    void explode()
    {
        for (int i = 0; i < House.transform.childCount; i++)
        {
            GameObject Go = House.transform.GetChild(i).gameObject;
            Vector3 daForce = new Vector3(Random.Range(-10f, 10f) * 15f, Random.Range(-10f, 10f) * 15f, Random.Range(-10f, 10f) * 15f);
            Go.GetComponent<Rigidbody>().AddForce(daForce);
        }
    }
}
