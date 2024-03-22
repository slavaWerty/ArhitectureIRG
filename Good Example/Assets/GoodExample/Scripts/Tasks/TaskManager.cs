using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TaskConfig _taskConfig;

    private MainTask _mainTask;

    private void Start()
    {
        _mainTask = new MainTask(_taskConfig);
    }
}

