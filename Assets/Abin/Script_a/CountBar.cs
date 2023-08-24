using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBar : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;

    public Vector2 size;
   // public LayerMask whatis;

    RectTransform hpbar;

    public float height = -0.25f;

    // Start is called before the first frame update
    void Start()
    {
        hpbar = Instantiate(prfHpBar,canvas.transform).GetComponent<RectTransform>();

        //오브젝트 범위에 충돌한 목록 확인

        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, size, 0);

        for (int i = 0; i < hit.Length; ++i)
        {
            Debug.Log(hit[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {   //오브젝트에 HP바 표시
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpbar.position = _hpBarPos;

    }

    void OnDrawGizmos()
    { //충돌체 범위 빨간색으로 보기
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
