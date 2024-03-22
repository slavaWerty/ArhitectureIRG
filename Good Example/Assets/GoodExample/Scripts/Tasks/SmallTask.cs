using System;
using UnityEngine;

[Serializable]
public class SmallTask : ITask
{
    [field: SerializeField] public string Name { get; set; }

    public event Action Executed;
    public bool IsExecuted => _isExecuted;

    private bool _isExecuted = false;

    public void Execution()
    {
        Executed?.Invoke();
        _isExecuted = true;
    }
}

