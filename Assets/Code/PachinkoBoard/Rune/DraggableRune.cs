using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class DraggableRune : MonoBehaviour
{
    [SerializeField]
    public Rune runeData;
    private PachinkoGameManager pachinkoGameManager;
    private bool isDragging = false;
    private bool isLocked = false;
    private Vector3 offset;
    private float originalZ;
    private Vector3 originalPosition;

    [SerializeField]
    Collider2D draggableCollider;
    private RuneDropSlot currentHoveredSlot;

    private void Start()
    {
        pachinkoGameManager = FindFirstObjectByType<PachinkoGameManager>();
        if (pachinkoGameManager == null)
        {
            Debug.LogError("PachinkoGameManager not found in the scene", this);
        }
        originalZ = transform.position.z;
    }


    private void OnMouseDown()
    {
        if (isLocked)
        {
            return;
        }
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
        draggableCollider.enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        draggableCollider.enabled = true;

        if (hit.collider == null)
        {
            ReturnToOriginalPosition();
            return;
        }

        RuneDropSlot runeSlot = hit.collider.GetComponent<RuneDropSlot>();
        if (runeSlot == null)
        {
            ReturnToOriginalPosition();
            return;
        }

        if (!runeSlot.CanAcceptRune(this))
        {
            ReturnToOriginalPosition();
            return;
        }

        transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, originalZ);
        runeSlot.SetOccupied(true, this);
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalZ);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RuneDropSlot slot = other.GetComponent<RuneDropSlot>();
        if (slot != null)
        {
            currentHoveredSlot = slot;
            slot.OnRuneHover(this);
        }
        
        if (other.gameObject.CompareTag("PachinkoBall"))
        {
            pachinkoGameManager.runeHit(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        RuneDropSlot slot = other.GetComponent<RuneDropSlot>();
        if (slot != null && slot == currentHoveredSlot)
        {
            slot.OnRuneExit();
            currentHoveredSlot = null;
        }
    }

    private void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
    }

    internal void lockRune()
    {
        isLocked = true;
    }
}
