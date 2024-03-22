using UnityEngine;

[CreateAssetMenu(menuName = "Game/new TaskConfig", fileName = "TaskConfig")]
public class TaskConfig : ScriptableObject
{
    [SerializeField] private MainTask _mainTask;

    public MainTask MainTask => _mainTask;
}

