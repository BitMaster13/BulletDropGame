using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable2D : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;
    private float originalZ;
    private Vector3 originalPosition;

    [SerializeField]
    Collider2D draggableCollider;

    private void Start()
    {
        originalZ = transform.position.z;
    }

    private void OnMouseDown()
    {
        // Record the difference between the mouse position and the object's position
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalZ));
        isDragging = true;
        originalPosition = transform.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        print("OnMouseUp");
        draggableCollider.enabled = false; // Disable the collider to prevent raycast hits on the same object

        // Check for valid drop zones using raycasts
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        draggableCollider.enabled = true; // Re-enable the collider after raycast checks
        
        if (hit.collider != null)
        {
            print("Hit: " + hit.collider.name);
            DropTarget2D dropTarget = hit.collider.GetComponent<DropTarget2D>();
            if (dropTarget != null)
            {
                print("DropTarget found");
                if (!dropTarget.IsOccupied)
                {
                    print("DropTarget is not occupied");
                    // Snap to the drop zone
                    transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, originalZ);
                    dropTarget.SetOccupied(true, this);
                }
                else
                {
                    print("DropTarget is occupied");
                    ReturnToOriginalPosition(); // Return if the slot is occupied
                }
            }
            else
            {
                print("DropTarget not found");
                ReturnToOriginalPosition(); // Return if not dropped on a valid zone
            }
        }
        else
        {
            print("No hit");
            ReturnToOriginalPosition(); // Return if not dropped on anything
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalZ);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    private void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
        // You might want to add a smooth animation here using Vector3.Lerp or a tweening library
    }
}
