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
            QTEProgressIndex = 0;
            StartCoroutine(CompletedQTE());
        }
    }

    private IEnumerator CompletedQTE()
    {
        // TODO: Add task completing animation here
        yield return new WaitForSeconds(1f);
        QTEManager.EndQTE();
    }
}
