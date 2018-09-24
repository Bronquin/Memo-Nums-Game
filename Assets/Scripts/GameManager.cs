using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 1;

    public void endGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("restart",restartDelay);
            
        }
    }

    void restart()
    {
        Vector3 newPos = new Vector3(0,5,6);
        GameObject.FindGameObjectWithTag("Player").transform.position = newPos;
        gameHasEnded = false;
    }

}
//restart would just reload position of ball instead
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);