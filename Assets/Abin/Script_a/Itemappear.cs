using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Itemappear : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;

    public bool isdown;
    public float Pushtime = 0;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pushtime == 5)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Target")
        {
            Debug.Log("이벤트발생");
            if (Input.GetKey(KeyCode.F))
            {
                Pushtime++;
                Debug.Log("채집 " + Pushtime + " 회");

            }

         
        }
    }
}
