using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(PlayerState), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private PlayerState _playerState;
    [ReadOnly]
    private IPlayerState _state;

    private void Start()
    {
        _state = new MoveState();
    }

    private void Update()
    {
        var nextState = _state.CheckTransition(_playerState);
        if(nextState != _state)
        {
            _state.StateLeave(_playerState);
            _state = nextState;
            _state.StateEnter(_playerState);
        }
        _state.StateUpdate(_playerState);
    }

    /// <summary>
    /// This is just to show a visual preview of the states
    /// </summary>
    private void LateUpdate()
    {
        _animator.SetFloat("YVel", _playerState.Velocity.y);
        _animator.SetFloat("YPos", transform.position.y);
        if(Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("JumpPressed");
        }
        else
        {
            _animator.ResetTrigger("JumpPressed");
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_playerState.Velocity.x * Time.fixedDeltaTime, _playerState.Velocity.y * Time.fixedDeltaTime);
    }

    private void Reset()
    {
        _playerState = GetComponent<PlayerState>();
        _animator = GetComponent<Animator>();
    }
}
