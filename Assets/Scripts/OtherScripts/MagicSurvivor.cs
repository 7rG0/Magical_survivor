using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState  // определяет, в каком состоянии находится игра ( можно использовать для паузы мб)
{
    IDLE,
    PLAYING,
    FINISHED

}

public class MagicSurvivor : MonoBehaviour
{
    [SerializeField] public GameState _gameState = GameState.IDLE; // переменная, которая храит текущее состояние игры

    private Timer timer;

    static public MagicSurvivor magicSurvivorS;
   

    public GameState GetGameState
    {
        get { return _gameState;}
    }

    private void Awake()
    {
        magicSurvivorS = this;
        timer = GetComponent<Timer>();
    }

    private void Start()
    {
        _gameState = GameState.PLAYING;
    }

    public void FinishGame()
    {
       _gameState = GameState.FINISHED;
        timer.StopTimer();
    }

    public void PauseGame()
    {
        _gameState = GameState.IDLE;
       
        
    }

    private void BackToMenu()  // функция, которая возвращает в главное меню
    {
        SceneManager.LoadScene("MainMenu");
    }
}
