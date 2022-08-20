using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public string sceneToLoad = "";
    
    public void LoadScene() {
        if (sceneToLoad != "")
            SceneManager.LoadScene(sceneToLoad);
        else
            Debug.Log("Please define the scene name in the editor.");
    }
}
