using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private PlayerStateController playerStateController;

    public PlayerStateController PlayerStateController { get => playerStateController; }

    private void Awake()
    {
        playerStateController = new PlayerStateController(this);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        playerStateController.Update();
    }

    #region PlayerIdle
    public void InputCheck()
    {
        if(Input.anyKeyDown)
        {
            SetStateMove();
        }
    }
    #endregion

    #region PlayerMove
    public void Move()
    {

    }
    #endregion

    #region SetState
    private void SetStateIdle()
    {
        playerStateController.ChangeState(PlayerIdle.Instance);
    }
    private void SetStateMove()
    {
        playerStateController.ChangeState(PlayerMove.Instance);
    }
    private void SetStateStop()
    {
        playerStateController.ChangeState(PlayerStop.Instance);
    }
    #endregion

}
