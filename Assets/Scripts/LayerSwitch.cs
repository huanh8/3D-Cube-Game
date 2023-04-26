using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitch : MonoBehaviour
{
    private BoxCollider _collider;
    public GameObject Submarine;
    [SerializeField] LayerMask _showLayer;
    [SerializeField] LayerMask _hideLayer;

    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        Submarine = GameObject.Find("Submarine");
    }

    // when the Submarine enters the collider, switch the Layer to _showLayer, 
    //when the Submarine exits the collider, switch the Layer to _hideLayer
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Submarine)
        {
            ChangeLayerRecursively(_collider.gameObject, _showLayer);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Submarine)
        {
            ChangeLayerRecursively(_collider.gameObject, _hideLayer);
        }
    }
    
    private void ChangeLayerRecursively(GameObject obj, LayerMask newLayer)
    {
        obj.layer = (int)Mathf.Log(newLayer.value, 2);
        foreach (Transform child in obj.transform)
        {
            ChangeLayerRecursively(child.gameObject, newLayer);
        }
    }
}
