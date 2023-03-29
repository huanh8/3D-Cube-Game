using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProceduralDrawer : MonoBehaviour
{
    public GameObject cubeContainerPrefab;
    
    public void CubeDrawing(Vector2Int drawPosition)
    {
        GameObject cubeContainer = Instantiate(cubeContainerPrefab, new Vector3(drawPosition.x, 0, drawPosition.y), Quaternion.identity);
        cubeContainer.transform.parent = transform;
    }

    public void ClearMap()
    {
        GameObject[] deleteObjects = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var deleteObject in deleteObjects)
        {
            Destroy(deleteObject);
        }
    }
}
