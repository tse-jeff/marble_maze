using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_level : MonoBehaviour
{
    public string levelName = "level2";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(levelName);
        }
    }
}
