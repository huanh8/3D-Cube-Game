using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEProgress : MonoBehaviour
{
    public List<GameObject> QTEProgressList;
    private int QTEProgressIndex = 0;
    public QTEManager QTEManager;
    
    // Success
    public void Success()
    {
        QTEProgressList[QTEProgressIndex].SetActive(true);
        QTEProgressIndex++;
    }

    // Fail
    public void Fail()
    {
        if (QTEProgressIndex > 0)
        {
            QTEProgressIndex--;
            QTEProgressList[QTEProgressIndex].SetActive(false);
        }
    }

    void Update()
    {
        if (QTEProgressIndex == QTEProgressList.Count)
        {
            Debug.Log("QTE Completed");
            CompletedQTE();
            ResetProgress();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit qte without complete it
            // A difference between EndQTE() is that 
            // we don't need to turn off qte box since it's incomplete
            QTEManager.QuitQTE();
            ResetProgress();
        }
    }

    private void CompletedQTE()
    {
        // TODO: Add task completing animation here
        QTEManager.EndQTE();
    }

    private void ResetProgress()
    {
        QTEProgressIndex = 0;
        foreach (GameObject qteProgress in QTEProgressList)
        {
            qteProgress.SetActive(false);
        }
    }
}
