using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float distanceToMove;

    public bool moveToPoint = false;
    public float detectionDistance;

    private Vector3 endPosition;
    
    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArr;
    private int spriteIndex;

    public BoxController boxController;
    public UndoManager undoManager;

    void Start()
    {
        endPosition = transform.position;
        undoManager = GameObject.Find("UndoManager").GetComponent<UndoManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
    }

    GameObject CheckCratePos(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionDistance, LayerMask.GetMask("Cube"));
        Debug.DrawRay(transform.position, transform.right, Color.green);

        if (hit.collider != null)
        {
            boxController = hit.transform.gameObject.GetComponent<BoxController>();
            boxController.CheckWallPos(direction);
        }
        return hit.collider?.gameObject;
    }

    private void FixedUpdate()
    {
        ableToMove();
    }

    void ableToMove()
    {
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
            moveToPoint = false;
        }
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
            var crate = CheckCratePos(Vector3.up);
            ChangePlayerSprite(Vector3.up);
            if (crate != null)
                undoManager.Push(new List<GameObject>(new[] {crate, gameObject}), Vector3.up);
            else
                undoManager.Push(new List<GameObject>(new[] {gameObject}), Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
             var crate = CheckCratePos(Vector3.left);
             ChangePlayerSprite(Vector3.left);
            if (crate != null)
                undoManager.Push(new List<GameObject>(new[] {crate, gameObject}), Vector3.left);
            else
                undoManager.Push(new List<GameObject>(new[] {gameObject}), Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
            var crate = CheckCratePos(Vector3.down);
            ChangePlayerSprite(Vector3.down);
            if (crate != null)
                undoManager.Push(new List<GameObject>(new[] {crate, gameObject}), Vector3.down);
            else
                undoManager.Push(new List<GameObject>(new[] {gameObject}), Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
            var crate = CheckCratePos(Vector3.right);
            ChangePlayerSprite(Vector3.right);
            if (crate != null)
                undoManager.Push(new List<GameObject>(new[] {crate, gameObject}), Vector3.right);
            else
                undoManager.Push(new List<GameObject>(new[] {gameObject}), Vector3.right);
        }
        moveToPoint = true;
    }

    void ChangePlayerSprite(Vector3 side)
    {
        Vector3 currentSide = side;

        switch(side)
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
