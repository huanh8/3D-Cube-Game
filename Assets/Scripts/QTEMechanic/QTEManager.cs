using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    public GameObject QTESystem;
    public GameObject QTEBar;
    public GameObject ProgressBar;

    void Start()
    {   // get the game object from its parent
        QTESystem = transform.parent.gameObject;
    }
    public void StartQTE()
    {
        QTEBar.SetActive(true);
        ProgressBar.SetActive(true);
    }

    public void EndQTE()
    {
        QTEBar.SetActive(false);
        ProgressBar.SetActive(false);
        DisableSystem();

    }
    public void DisableSystem()
    {
        QTESystem.SetActive(false);
    }
}
