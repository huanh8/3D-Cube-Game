using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    public GameObject QTEBar;
    public GameObject ProgressBar;

    private GameObject _qteArea;

    public void StartQTE(GameObject qteBox)
    {
        QTEBar.SetActive(true);
        ProgressBar.SetActive(true);
        _qteArea = qteBox;
    }

    public void EndQTE()
    {
        QTEBar.SetActive(false);
        ProgressBar.SetActive(false);
        _qteArea.SetActive(false);
    }

    public void QuitQTE()
    {
        QTEBar.SetActive(false);
        ProgressBar.SetActive(false);
    }
}
