using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareGenerate : MonoBehaviour
{
    private int positionFixed = 10;
    [SerializeField]
    private int randomIterations = 2;

    public MapProceduralDrawer mapProceduralDrawer;
    
    public void SquareMapGeneration()
    {
        HashSet<Vector2Int> squarePositions = SquareMap();

        // Drawing cube prefabs
        // clear the entire map before drawing (again)
        mapProceduralDrawer.ClearMap();
        foreach (var position in squarePositions)
        {
            // test-printing the positions of randomWalk cubes
            Debug.Log(position);
            mapProceduralDrawer.CubeDrawing(position);
        }
    }

    public HashSet<Vector2Int> SquareMap()
    {
        HashSet<Vector2Int> squarePositions = new HashSet<Vector2Int>();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                squarePositions.Add(new Vector2Int(i * positionFixed, j * positionFixed));
            }
        }

        for (int k = 0; k < randomIterations; k++)
        {
            squarePositions.Add(RandomPiece2D.GetRandomPiece());
        }

        return squarePositions;
    }

    
}

public static class RandomPiece2D
{
    public static List<Vector2Int> cardinalDirections = new List<Vector2Int>()
    {
        new Vector2Int((Random.Range(0, 3))*10, 40), // up
        new Vector2Int(40, (Random.Range(0, 3))*10), // right
        new Vector2Int((Random.Range(0, 3))*10, -10), // down
        new Vector2Int(-10, (Random.Range(0, 3))*10) // left
    };

    public static Vector2Int GetRandomPiece()
    {
        return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}
