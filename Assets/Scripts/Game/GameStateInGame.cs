using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateInGame : GameState
{
    public GameStateInGame(GameManager manager) : base(manager)
    {
        this.gameManager = manager;
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}
