using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [Header("Managers : ")]
    public static WinManager winScript;

    [Header("GameObjects : ")]
    public GameObject[] boxes;

    [Header("UI : ")]
    public GameObject winPanel;

    public HashSet<string> boxComplete;
    private int Goals;

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
