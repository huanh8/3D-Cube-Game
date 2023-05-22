using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterEffect : MonoBehaviour
{
    [SerializeField] GameObject _waterFx;
    // Start is called before the first frame update
    [SerializeField] List<GameObject> _containers = new List<GameObject>();
    void Start()
    {
        if (_waterFx != null) _waterFx.SetActive(false);
        // to find all the containers form sibling
        SetAllContainer();
    }

    private void SetAllContainer()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.gameObject.tag == "Container")
            {
                _containers.Add(child.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "MainCamera")
        {
            if (_waterFx != null) _waterFx.SetActive(true);
            RenderSettings.fog = true;
            HighlightContainer();
        }

    }

    // set all the containers to disable except the one that is in the trigger
    private void HighlightContainer()
    {
        foreach (GameObject container in _containers)
        {
            if (container != gameObject)
            {
                container.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if (other.gameObject.tag == "MainCamera")
        {
            if (_waterFx != null) _waterFx.SetActive(false);
            RenderSettings.fog = false;

            ActiveAllContainer();
        }
    }

    private void ActiveAllContainer()
    {
        // set all the containers to active
        foreach (GameObject container in _containers)
        {
            container.SetActive(true);
        }
    }
}
