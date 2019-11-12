using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMang : MonoBehaviour
{
    bool GameEnded = false;

    public void GameOver()
    {
        if(GameEnded == false)
        {
            GameEnded = true;
            Debug.Log("GAMEOVER!!");
            ResetGame();
        }
        
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
