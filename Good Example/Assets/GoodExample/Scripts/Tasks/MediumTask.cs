using System;
using UnityEngine;

[Serializable]
public class MediumTask : ITask
{
    [field: SerializeField] public string Name { get ; set; }

    [SerializeField] private SmallTask[] _smallTasks;

    private bool _isExecuted = false;

    public event Action Executed;
    public bool IsExecuted => _isExecuted;

    public void Execution()
    {
        for (int i = 0; i < _smallTasks.Length; i++)
            if (!_smallTasks[i].IsExecuted)
                return;

        Executed?.Invoke();
    }
}

