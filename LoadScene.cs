using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    GameStatus gameSts;
   
    public void LoadNextScene()
    {
        int loadDesiredScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(loadDesiredScene + 1);

    }

    private void Awake()
    {
        gameSts = FindObjectOfType<GameStatus>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadPrologueScene()
    {
        gameSts.Hallelujah();
        SceneManager.LoadScene(0);
    }

    

}
