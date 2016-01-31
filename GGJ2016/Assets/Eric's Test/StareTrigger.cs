using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GazeAwareComponent))]
public class StareTrigger : MonoBehaviour {
    public GameObject triggeredGameObject;

    private Material defaultMaterial;
    public Material StaredMaterial;
    private bool hasLookedAtBefore;
    private bool isStaring;
    private float startTime;
    private float delayTime = 0.5f;

    private static readonly Vector3 NormalScale = new Vector3(1.0f, 1.0f, 1.0f);
    private static readonly Vector3 LargeScale = new Vector3(1.1f, 1.1f, 1.1f);

    private float _scaleFactor = 0;

    public float speed = 0.5f;

    private GazeAwareComponent _gazeAwareComponent;
    // Use this for initialization
    void Start () {
        _gazeAwareComponent = GetComponent<GazeAwareComponent>();
        defaultMaterial = this.gameObject.GetComponent<Renderer>().material;
        hasLookedAtBefore = false;
        isStaring = false;
    }
	
	// Update is called once per frame
	void Update () {
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
    }

}
