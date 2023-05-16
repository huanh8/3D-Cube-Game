using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveQTE : MonoBehaviour
{
    public List<GameObject> dots;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("QTE"))
        {
            dots.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("QTE"))
        {
            dots.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
