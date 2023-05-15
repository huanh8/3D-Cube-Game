using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckQTE : MonoBehaviour
{
    private bool check;
    public GameObject activeZone;
    private List<GameObject> dots;
    public QTEProgress qteProgress;

    void Update()
    {
        dots = activeZone.GetComponent<ActiveQTE>().dots;
            if (Input.GetKeyDown(KeyCode.Space)) // the player hit the spacebar
            {
                GameObject dot = dots[0];
                if(dot)
                    if(check) // success
                    {
                        Debug.Log("Success");
                        check = false;
                        dots.Remove(dot);
                        Destroy(dot);
                        qteProgress.Success();
                    }
                    else // not successful
                    {
                        Debug.Log("Failed");
                        qteProgress.Fail();
                        StartCoroutine(DotFail(dot));
                    }
            }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("QTE"))
        {
            check = true;
        }
    }

    private IEnumerator DotFail(GameObject dot)
    {
        dot.GetComponent<QTEDot>().speed = 0;
        dot.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(1f);
        dots.Remove(dot);
        Destroy(dot);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("QTE") && check)
        {
            Debug.Log("Missing");
            check = false;
            dots.Remove(other.gameObject);
            Destroy(other.gameObject);
            qteProgress.Fail();
        }
    }
}
