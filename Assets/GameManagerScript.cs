using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameOverText;
    public AudioSource hitAudioSource;
    public TextMeshProUGUI scoreText;
    public GameObject bombParticle;

    private int score = 0;

    public bool IsGameOver()
    {
        return gameOverFlag;
    }

    public void Hit(Vector3 position)
    {
        // 爆発パーティクル発生
        Instantiate(bombParticle, position, Quaternion.identity);

        hitAudioSource.Play();
        score += 1;

        // 敵の発生
        int gameTimer = 0;
        gameTimer++;
        int max = 50 - gameTimer / 100;
        int r = Random.Range(0, max);
        if (r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0.0f, 15), Quaternion.identity);
        }
    }

    private bool gameOverFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        Instantiate(enemy, new Vector3(x, 0, 10), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // スコア表示
        scoreText.text = "SCORE" + score;
        
        if (gameOverFlag == true) 
        {    
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
            return;
        }
    }
    void FixedUpdate()
    {
        int r = Random.Range(0, 50);
        if (r == 0) 
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 15), Quaternion.identity);
        }
    }
    public void GameOverStart()
    {
        gameOverText.SetActive(true);
    }
}
