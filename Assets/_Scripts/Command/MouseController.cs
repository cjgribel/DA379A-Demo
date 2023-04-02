using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MouseController : Singleton<MouseController>
{
    [ShowIf("UnitSelected")]
    public Unit _selectedUnit;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var go = GetMouseOver();
            if(go != null && go.TryGetComponent<Unit>(out Unit unit))
            {
                _selectedUnit = unit;
            }
            else
            {
                _selectedUnit = null;
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            if (_selectedUnit == null) return;
            var target = GetMouseInWorld();
            var command = new MoveCommand(target);
            if(Input.GetKey(KeyCode.LeftShift))
                _selectedUnit.QueueCommand(command);
            else
                _selectedUnit.SetCommand(command);
        }
    }

    private static GameObject GetMouseOver()
    {
        var mousePos = Input.mousePosition;
        var mouseRay = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, float.MaxValue))
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    private static Vector3 GetMouseInWorld()
    {
        var mousePos = Input.mousePosition;
        var mouseRay = Camera.main.ScreenPointToRay(mousePos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up);
        if(groundPlane.Raycast(mouseRay, out float distance))
        {
            var point = mouseRay.GetPoint(distance);
            return point;
        }
        return Vector3.zero;
    }

    public bool UnitSelected() => _selectedUnit != null;
}
