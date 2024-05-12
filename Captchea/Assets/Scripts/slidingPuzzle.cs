using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPuzzle : MonoBehaviour
{
    public Transform[,] grid = new Transform[4, 4]; 
    public Vector2Int emptyTile = new Vector2Int(2, 2); 

    private void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        foreach (Transform child in transform)
        {
            Vector2Int pos = new Vector2Int((int)child.position.x, (int)child.position.y);
            grid[pos.x, pos.y] = child;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Transform clickedTile = hit.collider.transform;
                MoveTile(clickedTile);
            }
        }
    }

    private void MoveTile(Transform tile)
    {
        Vector2Int clickedPos = FindPosition(tile);
        if (IsAdjacentToEmpty(clickedPos))
        {
            SwapTiles(clickedPos, emptyTile);
            emptyTile = clickedPos;
        }
    }

    private Vector2Int FindPosition(Transform tile)
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (grid[x, y] == tile)
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return Vector2Int.zero;
    }

    private bool IsAdjacentToEmpty(Vector2Int pos)
    {
        return Mathf.Abs(pos.x - emptyTile.x) + Mathf.Abs(pos.y - emptyTile.y) == 1;
    }

    private void SwapTiles(Vector2Int pos1, Vector2Int pos2)
    {
        Transform temp = grid[pos1.x, pos1.y];
        grid[pos1.x, pos1.y] = grid[pos2.x, pos2.y];
        grid[pos2.x, pos2.y] = temp;

        Vector3 tempPos = grid[pos1.x, pos1.y].position;
        grid[pos1.x, pos1.y].position = grid[pos2.x, pos2.y].position;
        grid[pos2.x, pos2.y].position = tempPos;
    }
}
