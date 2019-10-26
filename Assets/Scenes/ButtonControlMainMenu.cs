using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControlMainMenu : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("GameDayScene");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
