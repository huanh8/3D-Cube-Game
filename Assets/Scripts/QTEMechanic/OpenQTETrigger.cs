using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Summary
// set the tag of the object to player
// this script is used to trigger the QTE event
///Summary
public class OpenQTETrigger : MonoBehaviour
{
    public QTEManager QTEManager;
    public GameObject notice;
    bool _isTriggered = false;
    // TODO: Notice animation for task (QTE event)

    void Update()
    {
        OnEnableQTE();
    }

    private void OnEnableQTE()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isTriggered)
        {
            Debug.Log("F pressed");
            QTEManager.StartQTE(this.gameObject);
            notice.SetActive(false);
            _isTriggered = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered"+ other.tag);
        if (other.CompareTag("Player"))
        {
            notice.SetActive(true);
            _isTriggered = true;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            notice.SetActive(false);
            _isTriggered = false;
        }   
    }

}
