using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScene : MonoBehaviour
{
    public int speed = 4;
    public Rigidbody2D rigid;

    void Awake()
    {
        // Player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void NextSceneWithString()
    {
        SceneManager.LoadScene("Battle");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("플레이어와 충돌");
            Debug.Log("전투씬으로 전환");

            NextSceneWithString();
        }
    }
}
