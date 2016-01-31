using UnityEngine;
using System.Collections;

public class TreasureChestActivated : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip audioClip;

	EnemyController mover;
	// Use this for initialization
	void Start () {
		mover = FindObjectOfType<EnemyController>();
	}
	
	// Update is called once per frame
	void EyeActivated()
	{
		mover.timeTomove = true;
		audioSource.clip = audioClip;
		audioSource.Play ();
	}
}
