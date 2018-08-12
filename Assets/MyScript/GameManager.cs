using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameStatus : int
    {
        GameOver = 0,
        LevelStart = 1,
        Playing = 2,
        EnemyDead = 3,
        Win = 4,
        NULL = 5,
    }

    public EnemyManager Enemy;
    public PlayerHealth Player;
    public BodyRC BodyRC;
    public GetBodySourceFromServer Server;

    private int maxLevel = 3;
    private int currentLevel = 1;
    private float timer = 0.0f;
    private static GameStatus gameStatus = GameStatus.EnemyDead;
    private LoadScene loadScene;
    
	void Start () 
    {
        loadScene = GetComponent<LoadScene>();
	}
	
	void Update () 
    {
        switch (gameStatus)
        {
            case GameStatus.GameOver:
                GameOver();
                break;
            case GameStatus.LevelStart:
                LevelStart();
                break;
            case GameStatus.Playing:
                Playing();
                break;
            case GameStatus.EnemyDead:
                EnemyDead();
                break;
            case GameStatus.Win:
                Win();
                break;
            default:
                break;
        }
	}

    void LevelStart()
    {
        if (EnemyManager.EnemyNum == 0 )
        {
            Enemy.SpawnEnemy(currentLevel - 1);
            Player.RestoreHealth();
        }       
        timer += Time.deltaTime;
        if (timer > 2.0f)
        {
            gameStatus = GameStatus.Playing;
            Server.SetPCStatus((int)GameStatus.Playing);
            timer = 0.0f;
        }
    }

    void Playing()
    {
        if (EnemyManager.EnemyNum == 0)
        {
            gameStatus = GameStatus.EnemyDead;
            Server.SetPCStatus((int)GameStatus.EnemyDead);
            currentLevel++;
        }
        else if( Player.GetCurrentHealth() <= 0)
        {           
            gameStatus = GameStatus.GameOver;
            Server.SetPCStatus((int)GameStatus.GameOver);
        }
    }

    void EnemyDead()
    {
        if (currentLevel > maxLevel)
        {
            gameStatus = GameStatus.Win;
            Server.SetPCStatus((int)GameStatus.Win);
        }
        
        if (!ProhibitedZone.inZone)
        {
            loadScene.Load(currentLevel - 1);
            if (currentLevel == 1 && !BodyRC.RaiseHand())
            {
                return;
            }
            gameStatus = GameStatus.LevelStart;
            Server.SetPCStatus((int)GameStatus.LevelStart);
            timer = 0.0f;            
        }       
    }

    void GameOver()
    {
        currentLevel = 1;
        timer += Time.deltaTime;
        if (timer > 6.0f)
        {
            Enemy.DestoryEnemy();
            gameStatus = GameStatus.EnemyDead;
            Server.SetPCStatus((int)GameStatus.EnemyDead);
            timer = 0.0f;
            ScoreManager.score = 0;
        }
    }

    void Win()
    {
        currentLevel = 1;
        timer += Time.deltaTime;
        if (timer > 6.0f)
        {
            gameStatus = GameStatus.EnemyDead;
            Server.SetPCStatus((int)GameStatus.EnemyDead);
            timer = 0.0f;
            ScoreManager.score = 0;
        }
    }

    public static GameStatus GetGameStatus()
    {
        return gameStatus;
    }

    public static void SetGameStatus(GameManager.GameStatus _status)
    {
        gameStatus = _status;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
