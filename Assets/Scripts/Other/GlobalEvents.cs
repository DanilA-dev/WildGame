using UnityEngine;
using UnityEngine.Events;
using System;


public enum GameState { Resumed, Paused, Victory}

public class GlobalEvents : MonoBehaviour
{
    public static GlobalEvents instance;
    public GameState gameState;


    [Header("Pause")]
    [SerializeField] private UnityEvent OnGamePause;
    [Header("Resume")]
    [SerializeField] private UnityEvent OnGameResume;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    private void LateUpdate()
    {
       switch(gameState)
        {
            case GameState.Paused:
                UnlockCursor();
                break;
            case GameState.Resumed:
                LockCursor();
                break;
            case GameState.Victory:
                UnlockCursor();
                break;
        }
    }

    public void PauseGame()
    {
        gameState = GameState.Paused;
        OnGamePause?.Invoke();
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        gameState = GameState.Resumed;
        OnGameResume?.Invoke();
        Time.timeScale = 1;
    }

    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
