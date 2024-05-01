using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public GameObject PausePanel, TutorialCanvas;   // Create object shown on Unity inspector

    // Move from menu scene to the first game scene
    public void StartGameButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Move from menu scene to the credit scene
    public void CreditButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Move from menu scene to the tutorial scene
    public void TutorialButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    //Move from credit scene to the menu scene
    public void CreditBackButton() { 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    //Move from tutorial scene to the menu scene
    public void TutorialBackButton()
    {

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    //Move from intro scene to the game scene
    public void ContinueButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    // Show pause menu after clicking on pause button
    public void Pause() { 

        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Close the pause menu and continue the game after clicking on resume button
    public void Resume() {

        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Show tutorial after clicking on tutorial button from pause menu
    public void PauseTutorialButton()
    {
        
        TutorialCanvas.SetActive(true);
    }

    // Close the tutorial page after clicking on the close button
    public void PauseTutorialCloseButton()
    {

        TutorialCanvas.SetActive(false);
    }

    // Exit the game (move to the tile menu scene)
    public void ExitButton()
    {

        Time.timeScale = 1;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        SceneManager.LoadScene("TitleMenuScene");
    }
}
