using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
