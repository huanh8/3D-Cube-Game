using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public HashSet<Vector2Int> squareHashSet;

    public void SceneChecker()
    {
        foreach (var position in squareHashSet)
        {
            Debug.Log(position);
        }
    }
}