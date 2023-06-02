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
    [SerializeField] public GameState _gameState = GameState.IDLE; // переменная, которая хранит текущее состояние игры

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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) 
        {
            PauseGame();
        }
    }

    public void FinishGame()
    {
       _gameState = GameState.FINISHED;
        timer.StopTimer();
    }

    public void PauseGame()
    {
        _gameState = GameState.IDLE;
        Time.timeScale = 0f;
       
        
    }

    private void BackToMenu()  // функция, которая возвращает в главное меню
    {
        SceneManager.LoadScene("MainMenu");
    }
}
