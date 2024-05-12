using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlidingPuzzle : MonoBehaviour, IPointerClickHandler
{
    // References to components
    private GridLayoutGroup gridLayout;
    private RectTransform myRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Get the GridLayoutGroup component in the parent object
        gridLayout = GetComponentInParent<GridLayoutGroup>();

        // Get the RectTransform component of the tile
        myRectTransform = GetComponent<RectTransform>();
    }

    // Function to handle pointer click event
    public void OnPointerClick(PointerEventData eventData)
    {
        // Get the index of this tile and the empty tile within the grid layout
        int myIndex = transform.GetSiblingIndex();
        int emptyIndex = GetEmptyTileIndex();

        // Swap the hierarchy if the tiles are adjacent
        if (IsAdjacent(myIndex, emptyIndex))
        {
            // Swap the hierarchy
            transform.SetSiblingIndex(emptyIndex);

            // Update the layout
            gridLayout.CalculateLayoutInputHorizontal();
            gridLayout.CalculateLayoutInputVertical();
            gridLayout.SetLayoutHorizontal();
            gridLayout.SetLayoutVertical();
        }
    }
    

// Function to check if two tiles are adjacent
private bool IsAdjacent(int index1, int index2)
{
    int gridSize = gridLayout.constraintCount;

    // Calculate row and column indices of both tiles
    int row1 = index1 / gridSize;
    int col1 = index1 % gridSize;
    int row2 = index2 / gridSize;
    int col2 = index2 % gridSize;

    // Check if the tiles are adjacent horizontally or vertically
    bool isHorizontalAdjacent = Mathf.Abs(col1 - col2) == 1 && row1 == row2;
    bool isVerticalAdjacent = Mathf.Abs(row1 - row2) == 1 && col1 == col2;

    return isHorizontalAdjacent || isVerticalAdjacent;
}




    // Function to get the index of the empty tile
    private int GetEmptyTileIndex()
    {
        // Find the GameObject with the "EmptyTile" tag
        GameObject emptyTile = GameObject.FindGameObjectWithTag("EmptyTile");

        if (emptyTile != null)
        {
            // Get the index of the empty tile
            return emptyTile.transform.GetSiblingIndex();
        }

        // If no empty tile is found, return -1
        return -1;
    }
}
