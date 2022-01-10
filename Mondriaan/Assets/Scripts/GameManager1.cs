using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;

    public GameObject[] enemy;
    public int[] enemyCount;
    public float spawnWait;
    public float startWait;

    public int startBos;            // 보스 몇점에 등장시키냐


    public Text scoreText;
    private int score;

    public Text gameOverText;
    bool isGameOver;

    public Text gameClearText;

    public GameObject restartButton;


    public PlayerScript player;
    public Image playerLifeImage;
    private Image[] playerLifeImages;
    public Canvas canvas;
    private int oldLife;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    
    void Start()
    {
        restartButton.SetActive(false);

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        isGameOver = false;
        gameOverText.text = "";

        playerLifeImages = new Image[player.playerLife];
        for(int i = 0; i < player.playerLife; i++)
        {
            playerLifeImages[i] = Instantiate(playerLifeImage);
            playerLifeImages[i].transform.SetParent(canvas.transform);
            playerLifeImages[i].rectTransform.localPosition = new Vector3(-150 + (20 * i), -270);
        }
        oldLife = player.playerLife;

    }

    void Update()
    {
        if (oldLife > player.playerLife)
        {
            oldLife = player.playerLife;
            if(oldLife < 0)
            {
                oldLife = 0;
            }
            for(int i= oldLife; i < playerLifeImages.Length; i++)
            {
                playerLifeImages[i].enabled = false;
            }
        }

        //if(score > startBos)
        //{
        //    enemyCount[0] = 0;
        //    enemyCount[1] = 0;
        //    Instantiate(enemy[2],new Vector3(0.11f,3.68f,0.0f), Quaternion.identity);
        //    score = 0;
        //}
    }

    void UpdateScore()
    {
        scoreText.text = "Hit " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < enemyCount[i]; j++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(6.0f, 8.0f), 0.0f);
                    Instantiate(enemy[i], spawnPosition, Quaternion.identity);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
            if (score > startBos)
            {

                Instantiate(enemy[2], new Vector3(0.11f, 3.68f, 0.0f), Quaternion.identity);
                break;
            }
            if (isGameOver)         // isGameOver == true;
            {
                break;
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        restartButton.SetActive(true);
        isGameOver = true;
    }

    public void GameClear()
    {
        gameClearText.text = "Game Clear";
        restartButton.SetActive(true);
        isGameOver = true;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);               // SceneManager.GetActiveScene().buildInde 이것을 함수에 넣어줌으로써 현재 씬을 다시 시작한다는 것으로 알려준다. Scene 여러개일 경우 Index가 각 Scene마다 다르므로 현재 Scene을 알려주는 것을 넣은것.
    }


}
