using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    public GameObject QTEBar;
    public GameObject ProgressBar;

    public void StartQTE()
    {
        QTEBar.SetActive(true);
        ProgressBar.SetActive(true);
    }

    public void EndQTE()
    {
        QTEBar.SetActive(false);
        ProgressBar.SetActive(false);
    }

}
