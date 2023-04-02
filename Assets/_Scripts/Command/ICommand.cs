using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    /// <summary>
    /// Excecutes the command
    /// </summary>
    /// <param name="unit"> The unit that runs the command </param>
    /// <returns> True if the command is completed </returns>
    bool Execute(Unit unit);

    /// <summary>
    /// Just for visual feedback in the Editor
    /// </summary>
    void DrawGizmo(Unit unit);
}
