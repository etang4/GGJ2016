using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public string levelToLoad;
   

    public void onClick() 
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
