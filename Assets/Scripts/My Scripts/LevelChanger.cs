using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string toTransition;
    public bool playerStartSl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name != toTransition && collision.tag == "Player")
        {
            if (playerStartSl)
            {
                TranferBetweenScenes.playerStartSleeping = true;
            }
            SceneManager.LoadScene(toTransition);
        } 
    }
}
