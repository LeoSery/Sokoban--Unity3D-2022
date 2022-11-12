using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float distanceToMove;

    private bool moveToPoint = false;
    private Vector3 endPosition;
    public float detectionDistance;

    public BoxController boxController;

    void Start()
    {
        endPosition = transform.position;
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
            CheckCratePos(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
            CheckCratePos(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
            CheckCratePos(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
            CheckCratePos(Vector3.right);
        }
        moveToPoint = true;
    }
}
