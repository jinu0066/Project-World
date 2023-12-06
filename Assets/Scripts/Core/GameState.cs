using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateNormal : Singleton<GameStateNormal>, IState<GameManager>
{
    public void Init()
    {

    }

    public void Enter(GameManager stateController)
    {

    }

    public void Exit(GameManager stateController)
    {

    }

    public void FixedUpdateActive(GameManager stateController)
    {

    }

    public void UpdateActive(GameManager stateController)
    {

    }
}

public class GameStatePause : Singleton<GameStatePause>, IState<GameManager>
{    
    public void Init()
    {
    }

    public void Enter(GameManager stateController)
    {

    }

    public void Exit(GameManager stateController)
    {

    }

    public void FixedUpdateActive(GameManager stateController)
    {

    }


    public void UpdateActive(GameManager stateController)
    {

    }
}

public class GameStateOver : Singleton<GameStateOver>, IState<GameManager>
{
    public void Init()
    {

    }

    public void Enter(GameManager stateController)
    {

    }

    public void Exit(GameManager stateController)
    {

    }

    public void FixedUpdateActive(GameManager stateController)
    {

    }

    public void UpdateActive(GameManager stateController)
    {

    }
}