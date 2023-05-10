using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEDot : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(speed * Vector3.down * Time.deltaTime);
    }
}
