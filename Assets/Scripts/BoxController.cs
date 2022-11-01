using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Goal")
        {
            Win.winScript.boxComplete.Add(gameObject.name);
            Win.winScript.CheckWin();
        }
    }
}
