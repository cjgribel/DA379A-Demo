using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerState : MonoBehaviour
{
    [ReadOnly]
    public Vector2 Velocity;
    public float Speed;
    public float JumpPower;
}
