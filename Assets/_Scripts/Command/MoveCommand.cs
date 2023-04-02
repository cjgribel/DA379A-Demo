using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MoveCommand : ICommand
{
    private Vector3 _target;
    public MoveCommand(Vector3 target) => _target = target;

    public bool Execute(Unit unit)
    {
        var position = unit.transform.position;
        var distance = Vector3.Distance(position, _target);
        if(distance < float.Epsilon)
        {
            return true;
        }

        if(unit.TryGetComponent(out MovementSpeed speed))
        {
            var dir = (_target - position).normalized;
            var velocity = speed.Value * Time.deltaTime * dir;
            if(velocity.magnitude > distance)
            {
                unit.transform.position = _target;
                return true;
            }
            else
            {
                var newPosition = position + velocity;
                unit.transform.position = newPosition;
                return false;
            }
        }
        return true;
    }

    public void DrawGizmo(Unit unit)
    {
        Gizmos.DrawWireSphere(_target, 0.5f);
        Gizmos.DrawLine(unit.transform.position, _target);
    }
}
