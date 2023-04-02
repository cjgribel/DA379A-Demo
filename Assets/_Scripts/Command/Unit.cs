using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [ShowNativeProperty]
    public int QueuedCommands => _commandQueue.Count;

    private Queue<ICommand> _commandQueue = new();
    private ICommand _currentCommand = null;

    public void QueueCommand(ICommand command) => _commandQueue.Enqueue(command);

    public void SetCommand(ICommand command)
    {
        _commandQueue.Clear();
        _currentCommand = command;
    }

    public bool HasCommand => _currentCommand != null;

    private void Update()
    {
        if(_currentCommand == null) GetNextCommand();
        if(_currentCommand != null) RunCommand();
    }

    private void GetNextCommand() => _currentCommand = _commandQueue.Count > 0 ? _commandQueue.Dequeue() : null;
    private void RunCommand() => _currentCommand = _currentCommand.Execute(this) ? null : _currentCommand;

    private void OnDrawGizmosSelected()
    {
        Color[] colours = new Color[]
        {
            Color.green,
            Color.yellow,
            Color.red,
            Color.magenta,
            Color.blue,
            Color.cyan,
            Color.gray
        };

        Gizmos.color = Color.green;
        _currentCommand?.DrawGizmo(this);
        int index = 1;
        foreach (var command in _commandQueue)
        {
            Gizmos.color = colours[index];
            command.DrawGizmo(this);
            index = Mathf.Min(++index, colours.Length - 1);
        }
    }

}
