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
	public bool timeToExit;

	public AudioSource audioSource;
	public AudioClip levelIntro;
	public AudioClip firstDone;
	public AudioClip secondDone;
	public AudioClip exit;

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
		timeToExit = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isRedSeen == true && (isBlueSeen == false || isYellowSeen == false)) {
			Destroy (Red);
		}
		if (isBlueSeen == true && (isRedSeen == false || isYellowSeen == false)) {
			Destroy (Blue);
		}
		if (isYellowSeen == true && (isBlueSeen == false || isRedSeen == true)) {
			Destroy (Yellow);
		}
		if (isRedSeen == true && isBlueSeen == true && isYellowSeen == true) {
			start2ndGroup = true;
			playFirstSound ();
		}
		if (start2ndGroup == true && Red2 != null) {
			Red2.GetComponent<EnemyController> ().setTimeToMoveTrue ();
		} 
		if ((is2ndRedSeen == true && Red2 != null) && start2ndGroup == true) {
			Red2.GetComponent<EnemyController> ().DestroyObject ();
			Blue2.GetComponent<EnemyController> ().setTimeToMoveTrue ();
		}
		if ((is2ndBlueSeen == true && Blue2 != null) && start2ndGroup == true) {
			Blue2.GetComponent<EnemyController> ().DestroyObject ();
			Yellow2.GetComponent<EnemyController> ().setTimeToMoveTrue ();
		}
		if ((is2ndYellowSeen == true && Yellow2 != null) && start2ndGroup == true) {
			Yellow2.GetComponent<EnemyController> ().DestroyObject ();
			playSecondSound ();
			timeToExit = true;
		}
		if (timeToExit == true) {
			StartCoroutine("FadeOut");
		}
	}

	void OnLevelWasLoaded () {
		audioSource.clip = levelIntro;
		audioSource.Play ();
	}
	IEnumerator FadeOut() 
	{
		float fadeTime = GameObject.Find("GameManager").GetComponent<Fading>().BeginFade(1);
		playExitSound ();			
		yield return new WaitForSeconds(fadeTime + 5f);
        Application.LoadLevel(3);
		Debug.Log("Faded Out");
	}

	bool firstSoundPlaying = false;
	void playFirstSound () {
		if (!firstSoundPlaying) {
			audioSource.clip = firstDone;
			audioSource.Play ();
			firstSoundPlaying = true;
		}
	}

	bool secondSoundPlaying = false;
	void playSecondSound () {
		if (!secondSoundPlaying) {
			audioSource.clip = secondDone;
			audioSource.Play ();
			secondSoundPlaying = true;
		}
	}

	bool exitSoundPlaying = false;
	void playExitSound () {
		if (!exitSoundPlaying) {
			audioSource.clip = exit;
			audioSource.Play ();
			exitSoundPlaying = true;
		}
	}
}
