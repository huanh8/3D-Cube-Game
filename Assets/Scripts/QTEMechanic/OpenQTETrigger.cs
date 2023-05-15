using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQTETrigger : MonoBehaviour
{
    public QTEManager QTEManager;
    public GameObject notice;
    // TODO: Notice animation for task (QTE event)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            notice.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                QTEManager.StartQTE();
                notice.SetActive(false);
            }
        }
    }
}
