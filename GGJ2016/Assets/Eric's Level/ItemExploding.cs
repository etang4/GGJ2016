using UnityEngine;
using System.Collections;

public class ItemExploding : MonoBehaviour {
    public GameObject player;
    bool exploded;
    
	// Use this for initialization
	void Start () {
        exploded = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(!exploded && Vector3.Distance(this.gameObject.transform.position,player.transform.position) < 30f)
        {
            exploded = true;
            explode();
        }
	}

    void explode()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject Go = this.gameObject.transform.GetChild(i).gameObject;
            Vector3 daForce = new Vector3(Random.Range(-10f, 10f)*15f, Random.Range(-10f, 10f) * 15f, Random.Range(-10f, 10f) * 15f);
            Go.GetComponent<Rigidbody>().AddForce(daForce);
        }
    }
}
