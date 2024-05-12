using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileSwapper : MonoBehaviour, IPointerClickHandler
{
    // References to components
    private GridLayoutGroup gridLayout;
    private RectTransform myRectTransform;
    private static TileSwapper previousTile;

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
        // If this is the first clicked tile, store it as the previous tile and return
        if (previousTile == null)
        {
            previousTile = this;
            return;
        }

        // Get the index of this tile and the previously clicked tile within the grid layout
        int myIndex = transform.GetSiblingIndex();
        int prevIndex = previousTile.transform.GetSiblingIndex();

        // Swap the hierarchy if the tiles are different
        if (myIndex != prevIndex)
        {
            // Get the RectTransform component of the previously clicked tile
            RectTransform prevTileRectTransform = previousTile.GetComponent<RectTransform>();

            // Swap the hierarchy
            transform.SetSiblingIndex(prevIndex);
            prevTileRectTransform.SetSiblingIndex(myIndex);

            // Update the layout
            gridLayout.CalculateLayoutInputHorizontal();
            gridLayout.CalculateLayoutInputVertical();
            gridLayout.SetLayoutHorizontal();
            gridLayout.SetLayoutVertical();
        }

        // Reset the previously clicked tile
        previousTile = null;
    }
}
