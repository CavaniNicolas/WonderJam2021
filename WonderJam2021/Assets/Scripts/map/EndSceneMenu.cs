using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndSceneMenu : MonoBehaviour
{

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);

    }
}
