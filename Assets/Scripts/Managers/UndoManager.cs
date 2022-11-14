using System.Collections.Generic;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    private Stack<System.Tuple<List<GameObject>, Vector3>> Actions = new();
    public PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Undo()
    {
        var newAction = Actions.Pop();
        foreach (var gameObject in newAction.Item1)
        {
            gameObject.transform.Translate(-newAction.Item2);
            playerController.targetPosition = gameObject.transform.position;
        }

    }

    public void Push(List<GameObject> objects, Vector3 direction)
    {
        Actions.Push(new System.Tuple<List<GameObject>, Vector3>(objects, direction));
    }
}
