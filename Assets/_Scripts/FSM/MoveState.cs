using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IPlayerState
{
    public IPlayerState CheckTransition(PlayerState player)
    {
        if(Input.GetButtonDown("Jump"))
        {
            return new JumpState();
        }
        return this;
    }

    public void StateEnter(PlayerState player)
    {

    }

    public void StateLeave(PlayerState player)
    {

    }

    public void StateUpdate(PlayerState player)
    {
        var dir = Input.GetAxis("Horizontal");
        player.Velocity = dir * player.Speed * Vector2.right;
    }
}
