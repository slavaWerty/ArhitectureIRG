using System;
using UnityEngine;

[Serializable]
public class MainTask : ITask
{
    [field: SerializeField] public string Name { get ; set ; }

    [SerializeField] private MediumTask[] _tasks;

    public MediumTask[] Tasks;

    public MainTask(TaskConfig config)
    {
        _tasks = config.MainTask.Tasks;
    }

    private void Execution()
    {
        for (int i = 0; i < _tasks.Length; i++)
            if (!_tasks[i].IsExecuted)
                return;

        Debug.Log("Конец");
    }
}

