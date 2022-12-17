using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Script Settings :")]
    public float movementSpeed;
    public float distanceToMove;
    public float detectionDistance;

    [HideInInspector]
    public Vector3 targetPosition;

    [Header("Sprites :")]
    public Sprite[] spriteArr;

    private SpriteRenderer spriteRenderer;

    private BoxController boxController;

    private UndoManager undoManager;
    private UIManager uiManager;

    void Start()
    {
        undoManager = GameObject.Find("UndoManager").GetComponent<UndoManager>();
        uiManager = GameObject.Find("LevelManager").GetComponent<UIManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
    }

    void Update()
    {
        if (uiManager.gameIsPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                targetPosition = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);
                ChangePlayerSprite(Vector3.up);
                var crate = CheckCratePos(Vector3.up);
                SaveObjectsPos(crate, Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetPosition = new Vector3(transform.position.x - distanceToMove, transform.position.y, transform.position.z);
                ChangePlayerSprite(Vector3.left);
                var crate = CheckCratePos(Vector3.left);
                SaveObjectsPos(crate, Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                targetPosition = new Vector3(transform.position.x, transform.position.y - distanceToMove, transform.position.z);
                ChangePlayerSprite(Vector3.down);
                var crate = CheckCratePos(Vector3.down);
                SaveObjectsPos(crate, Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetPosition = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
                ChangePlayerSprite(Vector3.right);
                var crate = CheckCratePos(Vector3.right);
                SaveObjectsPos(crate, Vector3.right);
            }
            Move();
        }
    }

    public void Move()
    {
        if (targetPosition != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
    }

    void SaveObjectsPos(GameObject crate, Vector3 direction)
    {
        if (crate != null)
            undoManager.Push(new List<GameObject>(new[] { crate, gameObject }), direction);
        else
            undoManager.Push(new List<GameObject>(new[] { gameObject }), direction);
    }

    GameObject CheckCratePos(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + direction, direction, detectionDistance, LayerMask.GetMask("Cube"));
        Debug.DrawRay(transform.position, transform.right, Color.green, 2f);

        if (hit.collider != null)
        {
            boxController = hit.transform.gameObject.GetComponent<BoxController>();
            boxController.CheckWallPos(direction);
        }
        return hit.collider?.gameObject;
    }

    void ChangePlayerSprite(Vector3 side)
    {
        switch (side)
        {
            case Vector3 v when v.Equals(Vector3.up):
                spriteRenderer.sprite = spriteArr[0];
                break;
            case Vector3 v when v.Equals(Vector3.left):
                spriteRenderer.sprite = spriteArr[1];
                break;
            case Vector3 v when v.Equals(Vector3.down):
                spriteRenderer.sprite = spriteArr[2];
                break;
            case Vector3 v when v.Equals(Vector3.right):
                spriteRenderer.sprite = spriteArr[3];
                break;
        }
    }
}