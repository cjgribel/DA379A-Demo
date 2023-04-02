using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void StateEnter(PlayerState player);
    void StateLeave(PlayerState player);
    void StateUpdate(PlayerState player);
    IPlayerState CheckTransition(PlayerState player);
}
