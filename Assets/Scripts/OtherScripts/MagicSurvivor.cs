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
    [SerializeField] static public GameState _gameState = GameState.IDLE; // переменная, которая храит текущее состояние игры

   

    static public GameState GetGameState
    {
        get { return _gameState;}
    }

    static private void Awake()
    {

    }

    static private void Start()
    {
        _gameState = GameState.PLAYING;
    }

    static public void FinishGame()
    {
       _gameState = GameState.FINISHED;
    }

    static public void PauseGame()
    {
        _gameState = GameState.IDLE;
       
        
    }

    private void BackToMenu()  // функция, которая возвращает в главное меню
    {
        SceneManager.LoadScene("MainMenu");
    }
}
