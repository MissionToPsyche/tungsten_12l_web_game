using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Load starting game scene
    public void OnEnable()
    {

        SceneManager.LoadScene("TitleMenuScene", LoadSceneMode.Single);
    }
}
