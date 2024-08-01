using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        float movespeed = 2.0f;
        rb.velocity = new Vector3(0, 0, movespeed);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // �Q�[���}�l�[�W���[�̃X�N���v�g���l��
            GameObject gameManager;
            GameManagerScript gameManagerScript;
            gameManager = GameObject.Find("GameManager");
            gameManagerScript = gameManager.GetComponent<GameManagerScript>();

            // �Q�[���}�l�[�W���[�X�N���v�g�̏Փ˔�����Ăяo��
            gameManagerScript.Hit(transform.position);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}