using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public GameObject bullet;
    public GameObject gameManager;
    private GameManagerScript gameManagerScript;
    float bulletTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameManagerScript.GameOverStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 2.0f;
        float stageMax = 4.0f;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x < stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
            }
            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-moveSpeed, 0, 0);
            animator.SetBool("move", true);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("move", false);
        }
        if (gameManagerScript.IsGameOver() == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }
        return;
    }
    void FixedUpdate()
    {
        if (bulletTimer == 0)
        {
            //’e”­ŽË
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z += 1.0f;

                Instantiate(bullet, position, Quaternion.identity);
            }

            //”­ŽË‚µ‚½‚çƒ^ƒCƒ}[‚ð‚P‚É‚·‚é
            bulletTimer = 1;
        }
        else
        {
            bulletTimer++;
            if (bulletTimer > 20)
            {
                bulletTimer = 0;
            }
        }
    }

}
