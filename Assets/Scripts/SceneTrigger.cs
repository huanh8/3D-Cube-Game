using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public GameObject sceneManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneManager.GetComponent<SceneManager>().SceneChecker();
        }
    }

    public void OnMouseDown()
    {
        sceneManager.GetComponent<SceneManager>().SceneChecker();
    }
}