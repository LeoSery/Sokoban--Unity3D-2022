using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static Win winScript;
    public GameObject[] boxes;
    private int Goals;
    public GameObject winPanel;
    public HashSet<string> boxComplete;

    private void Awake()
    {
        winScript = this;
        winPanel.SetActive(false);
    }

    void Start()
    {
        boxComplete = new HashSet<string>();
        Goals = boxes.Length;
    }

    public void CheckWin()
    {
        if (Goals == boxComplete.Count)
        {
            winPanel.SetActive(true);
        }
    }
}
