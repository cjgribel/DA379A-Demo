using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(PlayerState))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerState m_playerState;
    [ReadOnly]
    private IPlayerState m_state;

    private void Start()
    {
        m_state = new MoveState();
    }

    private void Update()
    {
        var nextState = m_state.CheckTransition(m_playerState);
        if(nextState != m_state)
        {
            m_state.StateLeave(m_playerState);
            m_state = nextState;
            m_state.StateEnter(m_playerState);
        }
        m_state.StateUpdate(m_playerState);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(m_playerState.Velocity.x * Time.fixedDeltaTime, m_playerState.Velocity.y * Time.fixedDeltaTime);
    }

    private void Reset()
    {
        m_playerState = GetComponent<PlayerState>();
    }
}
