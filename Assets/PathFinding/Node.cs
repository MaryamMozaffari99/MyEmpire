using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Node
{
    public Vector2Int coordinates = new Vector2Int (2, 3);
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connecetedTo; 
    
    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}


