using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float distanceToMove = 50f;
    public float detectionDistance = 0.5f;

    private Vector2 currentTarget;
    public PlayerController playerController;

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void CheckWallPos(Vector3 direction)
    {
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position + direction, direction, detectionDistance, LayerMask.GetMask("Wall"));
        RaycastHit2D hitOtherCrate = Physics2D.Raycast(transform.position + direction, direction, detectionDistance, LayerMask.GetMask("Cube"));

        if (hitWall.collider == null && hitOtherCrate.collider == null)
        {
            MoveCrate(direction);
        }
    }

    public void MoveCrate(Vector3 direction)
    {
        currentTarget = transform.position + direction;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, 0.5f);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Goal")
        {
            Win.winScript.boxComplete.Add(gameObject.name);
            Win.winScript.CheckWin();
        }
    }
}
