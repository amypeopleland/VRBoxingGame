using UnityEngine;
using System.Collections;

public class GameManagerPC : MonoBehaviour 
{
    //public enum GameStatus : int
    //{
    //    GameOver = 0,
    //    LevelStart = 1,
    //    Playing = 2,
    //    EnemyDead = 3,
    //    Win = 4,
    //    NULL = 5,
    //}

    public EnemyManager Enemy;
    public PlayerHealth Player;

    private int maxLevel = 3;
    private int currentLevel = 1;
    private float timer = 0.0f;
    private static GameManager.GameStatus gameStatus = GameManager.GameStatus.NULL;
    private LoadScene loadScene;
	// Use this for initialization
	void Start () 
    {
        loadScene = GetComponent<LoadScene>();
	}
	
	void Update () 
    {
        if (gameStatus != GameManager.GameStatus.NULL)
        {
            switch (gameStatus)
            {
                case GameManager.GameStatus.GameOver:
                    GameOver();
                    break;
                case GameManager.GameStatus.LevelStart:
                    LevelStart();
                    break;
                case GameManager.GameStatus.Playing:
                    Playing();
                    break;
                case GameManager.GameStatus.EnemyDead:
                    EnemyDead();
                    break;
                case GameManager.GameStatus.Win:
                    Win();
                    break;
                default:
                    break;
            }
            gameStatus = GameManager.GameStatus.NULL;
        }
        
	}

    void LevelStart()
    {
        loadScene.Load(currentLevel - 1);
        Enemy.SpawnEnemy(currentLevel - 1);
        Player.RestoreHealth();
        //if (EnemyManager.EnemyNum == 0)
        //{
        //    Enemy.SpawnEnemy(currentLevel - 1);
        //    Player.RestoreHealth();
        //}
        //timer += Time.deltaTime;
        //if (timer > 2.0f)
        //{
        //    gameStatus = GameManager.GameStatus.Playing;
        //    timer = 0.0f;
        //}
    }

    void Playing()
    {
        //if (EnemyManager.EnemyNum == 0)
        //{
        //    gameStatus = GameManager.GameStatus.EnemyDead;
        //    currentLevel++;
        //}
        //else if (Player.GetCurrentHealth() <= 0)
        //{
        //    gameStatus = GameManager.GameStatus.GameOver;
        //}
    }

    void EnemyDead()
    {
        Enemy.DestoryEnemy();
        currentLevel++;
        //if (currentLevel > maxLevel)
        //{
        //    gameStatus = GameManager.GameStatus.Win;
        //}
        //if (!ProhibitedZone.inZone)
        //{
        //    loadScene.Load(currentLevel - 1);
        //    if (currentLevel == 1 && !BodyRC.RaiseHand())
        //    {
        //        return;
        //    }
        //    gameStatus = GameManager.GameStatus.LevelStart;

        //}
    }

    void GameOver()
    {
        currentLevel = 0;
        //timer += Time.deltaTime;
        //if (timer > 6.0f)
        //{
        //    Enemy.DestoryEnemy();
        //    gameStatus = GameManager.GameStatus.EnemyDead;
        //    timer = 0.0f;
        //    ScoreManager.score = 0;
        //}
    }

    void Win()
    {
        currentLevel = 0;
        //timer += Time.deltaTime;
        //if (timer > 6.0f)
        //{
        //    gameStatus = GameManager.GameStatus.EnemyDead;
        //    timer = 0.0f;
        //    ScoreManager.score = 0;
        //}
    }

    public static void SetGameStatus(GameManager.GameStatus _status)
    {
        gameStatus = _status;
    }

    public static GameManager.GameStatus GetGameStatus()
    {
        return gameStatus;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
