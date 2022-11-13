using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void changeSprite()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        changeSprite();
        LockCrate(collider, true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        changeSprite();
        LockCrate(collider, false);
    }

    private void LockCrate(Collider2D crate, bool state)
    {
        if (state)
            crate.transform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        else
            crate.transform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            crate.transform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
