using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GazeAwareComponent))]
public class StareTrigger : MonoBehaviour {
    public GameObject triggeredGameObject;

    private Material defaultMaterial;
    public Material StaredMaterial;
<<<<<<< HEAD

=======
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
    private bool hasLookedAtBefore;
    private bool isStaring;
    private float startTime;
    private float delayTime = 0.5f;

<<<<<<< HEAD
    private static readonly Vector3 NormalScale = new Vector3(1.0f, 1.0f, 1.0f);
    private static readonly Vector3 LargeScale = new Vector3(1.1f, 1.1f, 1.1f);
=======
    private Vector3 NormalScale;
    private Vector3 LargeScale;
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3

    private float _scaleFactor = 0;

    public float speed = 0.5f;

<<<<<<< HEAD
    private GazeAwareComponent _gazeAwareComponent;
    // Use this for initialization
    void Start () {
=======
    private GameObject player;

    private GazeAwareComponent _gazeAwareComponent;
    // Use this for initialization
    void Start () {
        NormalScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        LargeScale = new Vector3(this.gameObject.transform.localScale.x* 1.1f, this.gameObject.transform.localScale.y* 1.1f, this.gameObject.transform.localScale.z* 1.1f);
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
        _gazeAwareComponent = GetComponent<GazeAwareComponent>();
        defaultMaterial = this.gameObject.GetComponent<Renderer>().material;
        hasLookedAtBefore = false;
        isStaring = false;
<<<<<<< HEAD
=======
        player = GameObject.Find("Player");
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
    }
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        if (_gazeAwareComponent.HasGaze)
        {
            _scaleFactor = Mathf.Clamp01(_scaleFactor + speed * Time.deltaTime);
            if (!hasLookedAtBefore)
            {
                hasLookedAtBefore = true; 
                startTime = Time.time;
            }
            else if (Time.time > startTime + delayTime*2f)
            {
                triggeredGameObject.transform.SendMessage("EyeActivated");
            }
            else if(Time.time > startTime + delayTime)
            {
                this.GetComponent<Renderer>().material = StaredMaterial;
                isStaring = true;
            }
        }
        else
        {
            hasLookedAtBefore = false;
            _scaleFactor = Mathf.Clamp01(_scaleFactor - speed * Time.deltaTime);
            if (isStaring)
            {
                this.GetComponent<Renderer>().material = defaultMaterial;
                isStaring = false;
            }
        }
        transform.localScale = Vector3.Slerp(NormalScale, LargeScale, _scaleFactor);
=======
            if (_gazeAwareComponent.HasGaze && player.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                _scaleFactor = Mathf.Clamp01(_scaleFactor + speed * Time.deltaTime);
                if (!hasLookedAtBefore)
                {
                    hasLookedAtBefore = true;
                    startTime = Time.time;
                }
                else if (Time.time > startTime + delayTime * 2f)
                {
                    triggeredGameObject.transform.SendMessage("EyeActivated");
                }
                else if (Time.time > startTime + delayTime)
                {
                    this.GetComponent<Renderer>().material = StaredMaterial;
                    isStaring = true;
                }
            }
            else
            {
                hasLookedAtBefore = false;
                _scaleFactor = Mathf.Clamp01(_scaleFactor - speed * Time.deltaTime);
                if (isStaring)
                {
                    this.GetComponent<Renderer>().material = defaultMaterial;
                    isStaring = false;
                }
            }
            transform.localScale = Vector3.Slerp(NormalScale, LargeScale, _scaleFactor);
        
>>>>>>> 9ecf4ecf469e56176c648faa301153717903dad3
    }
}
