using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IfHit : MonoBehaviour
{
    public string sceneToLoad;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag (optional)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(2);
        }
    }
}
