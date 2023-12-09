using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : Singleton<PlayerIdle>, IState<PlayerController>
{
    public void Init()
    {

    }
    public void Enter(PlayerController stateController)
    {

    }

    public void Exit(PlayerController stateController)
    {

    }

    public void FixedUpdateActive(PlayerController stateController)
    {
    }

    public void UpdateActive(PlayerController stateController)
    {
        stateController.InputCheck();
    }
}

public class PlayerMove : Singleton<PlayerMove>, IState<PlayerController>
{
    public void Init()
    {

    }
    public void Enter(PlayerController stateController)
    {

    }

    public void Exit(PlayerController stateController)
    {

    }
    public void UpdateActive(PlayerController stateController)
    {
        stateController.MoveUpdate();
    }

    public void FixedUpdateActive(PlayerController stateController)
    {
        stateController.MoveFixedUpdate();
    }
}

public class PlayerStop : Singleton<PlayerStop>, IState<PlayerController>
{
    public void Init()
    {

    }
    public void Enter(PlayerController stateController)
    {

    }

    public void Exit(PlayerController stateController)
    {

    }

    public void FixedUpdateActive(PlayerController stateController)
    {

    }
    public void UpdateActive(PlayerController stateController)
    {

    }
}
