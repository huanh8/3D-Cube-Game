using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class RandomWalkGenerator : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    [SerializeField]
    private int iterations = 10;

    public int walkLength = 10;
    public bool startRandomlyEachIteration = true;

    public void ProceduralGeneration()
    {
        HashSet<Vector2Int> cubePositions = RandomWalk();
        // test printing
        foreach (var position in cubePositions)
        {
            Debug.Log(position);
        }
    }

    protected HashSet<Vector2Int> RandomWalk()
    {
        HashSet<Vector2Int> cubePositions = new HashSet<Vector2Int>();

        cubePositions.Add(startPosition);
        Vector2Int currentPosition = startPosition;

        for (int i = 0; i < iterations; i++)
        {
            if (startRandomlyEachIteration)
            {
                currentPosition = cubePositions.ElementAt(Random.Range(0, cubePositions.Count));
            }

            cubePositions.Add(currentPosition);

            for (int j = 0; j < walkLength; j++)
            {
                currentPosition += Direction2D.GetRandomCardinalDirection();
                cubePositions.Add(currentPosition);
            }
        }

        return cubePositions;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirections = new List<Vector2Int>()
    {
        new Vector2Int(0, 1), // up
        new Vector2Int(1, 0), // right
        new Vector2Int(0, -1), // down
        new Vector2Int(-1, 0) // left
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}
