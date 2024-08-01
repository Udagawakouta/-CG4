using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, 5);
        // ゲームマネージャーのオブジェクトを探す
        gameManager = GameObject.Find("GameManager");
        // スクリプトを獲得
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        int r = Random.Range(0, 2);
        if (r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 2.0f;

        Vector3 velosity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        transform.position += transform.rotation * velosity;
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }
        // 左右で回転
        if (transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
        if (transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
    }
}
