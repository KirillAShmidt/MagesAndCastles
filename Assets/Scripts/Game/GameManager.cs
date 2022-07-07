using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private State state;

    public Action<State> OnSceneChanged;
    public static GameManager Instance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        state = State.start;
        Instance = this;
    }

    private void EnterState()
    {
        switch (state)
        {
            case State.start:
                StartHandler();
                break;
            case State.inGame:
                InGameHandler();
                break;
            case State.end:
                EndHandler();
                break;
        }
    }

    private void StartHandler()
    {
        SceneManager.LoadScene("StartMenu");
    }

    private void InGameHandler()
    {
        SceneManager.LoadScene("Game");
    }

    private void EndHandler()
    {
        SceneManager.LoadScene("EndMenu");
    }

    public void ChangeState(State state)
    {
        this.state = state;
        OnSceneChanged?.Invoke(state);

        EnterState();

        Debug.Log("StateChanged");
    }
}
