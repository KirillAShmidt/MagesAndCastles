public abstract class GameState
{
    public GameManager gameManager;

    public GameState(GameManager manager)
    {
        this.gameManager = manager;
    }

    public abstract void Enter();
    public abstract void Exit();
}
