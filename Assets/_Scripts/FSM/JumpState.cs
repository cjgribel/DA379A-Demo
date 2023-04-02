using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerState
{
    public IPlayerState CheckTransition(PlayerState player)
    {
        if(player.transform.position.y <= 0 && player.Velocity.y < 0)
        {
            return new MoveState();
        }
        return this;
    }

    public void StateEnter(PlayerState player)
    {
        player.Velocity.y = player.JumpPower;
    }

    public void StateLeave(PlayerState player)
    {
        player.Velocity.y = 0;
        var pos = player.transform.position;
        pos.y = 0;
        player.transform.position = pos;
    }

    public void StateUpdate(PlayerState player)
    {
        player.Velocity += 9.82f * Time.deltaTime * Vector2.down;
    }
}
