using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip musicClip;

    void Awake() {
        //DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
        audioSource.clip = musicClip;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
