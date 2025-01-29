using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable2D : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject draggedObject;
    public Vector3 startPosition;
    private Transform startParent;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        mainCamera = Camera.main; // Get the main camera automatically
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag called on: " + gameObject.name);
        draggedObject = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;

        // Optional: Visual feedback
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.7f); // Make it slightly transparent
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert mouse position to world space for 2D
        Vector3 screenPoint = eventData.position;
        screenPoint.z = -mainCamera.transform.position.z; // Distance from camera to the sprite plane
        transform.position = mainCamera.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Optional: Reset visual changes
        spriteRenderer.color = Color.white;
    }
}
