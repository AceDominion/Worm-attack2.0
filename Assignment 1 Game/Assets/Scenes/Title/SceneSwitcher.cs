using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	public void SwitchScene(string sceneName)
    {
        //play
        //自动进入最后一个level 

        //level
        //进入level scene

        //credit
        //展现 name 本次共收集到的totem
        SceneManager.LoadScene (sceneName);

        Debug.Log (SceneManager.GetSceneByName ("Title").isLoaded);
        if (SceneManager.GetSceneByName ("Title").isLoaded == false) {
           
        }
    }
}
