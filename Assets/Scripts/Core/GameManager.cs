using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : StateController<GameManager>
{
    public GameStateController(GameManager owner) : base(owner)
    {
        Init();
    }

    public void Init()
    {
    }
}


public class GameManager
{
    private GameStateController gameStateController;

    public IState<GameManager> CurState { get => gameStateController.CurState; }

    public void Init()
    {
        gameStateController = new GameStateController(this);
    }

    #region SetState
    public void SetStateNormal() => gameStateController.ChangeState(GameStateNormal.Instance);
    public void SetStatePause() => gameStateController.ChangeState(GameStatePause.Instance);
    public void SetStateGameOver() => gameStateController.ChangeState(GameStateOver.Instance);
    #endregion
}