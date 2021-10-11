using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndSceneMenu : MonoBehaviour
{

    public void OpenMainMenu()
    {
        Destroy(GameObject.Find("GameUI"));
        Destroy(GameObject.Find("AudioManager"));
        Destroy(GameObject.Find("PauseManager"));

        Debug.Log("Open MainMenu");
        SceneManager.LoadScene("SceneMainMenu");

    }
}
