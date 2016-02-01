using UnityEngine;
using System.Collections;

public class TreasureChestActivated : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip audioClip;

	EnemyController mover;
	// Use this for initialization
	void Start () {
		mover = FindObjectOfType<EnemyController>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void EyeActivated()
	{
		mover.timeTomove = true;
		
        StartCoroutine("FadeOut");
	}
    IEnumerator FadeOut()
    {
        float fadeTime = GameObject.Find("GM").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Debug.Log("Faded Out");
        Application.Quit();
    }

}
