using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class DraggableRune : MonoBehaviour
{
    [SerializeField]
    public RuneShape shape;
    private PachinkoGameManager pachinkoGameManager;
    public RuneData runeData;
    private bool isDragging = false;
    private bool isLocked = false;
    private Vector3 offset;
    private float originalZ;
    private Vector3 originalPosition;

    [SerializeField]
    Collider2D draggableCollider;

    private void Start()
    {
        pachinkoGameManager = FindFirstObjectByType<PachinkoGameManager>();
        if (pachinkoGameManager == null)
        {
            Debug.LogError("PachinkoGameManager not found in the scene", this);
        }
        originalZ = transform.position.z;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PachinkoBall"))
        {
            pachinkoGameManager.runeHit(this);
        }
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
        if (isLocked)
        {
            return;
        }
        
        isDragging = false;
        print("OnMouseUp");
        draggableCollider.enabled = false; // Disable the collider to prevent raycast hits on the same object

        // Check for valid drop zones using raycasts
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        draggableCollider.enabled = true; // Re-enable the collider after raycast checks

        if (hit.collider != null)
        {
            print("Hit: " + hit.collider.name);
            RuneDropSlot runeSlot = hit.collider.GetComponent<RuneDropSlot>();
            if (runeSlot != null)
            {
                print("DropTarget found");
                if (!runeSlot.CanAcceptRune(this))
                {
                    print("DropTarget cannot accept rune");
                    ReturnToOriginalPosition(); // Return if the slot cannot accept the rune
                }
                else if (!runeSlot.IsOccupied)
                {
                    print("DropTarget is not occupied");
                    // Snap to the drop zone
                    transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, originalZ);
                    runeSlot.SetOccupied(true, this);
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

    internal void lockRune()
    {
        isLocked = true;
    }
    
}
