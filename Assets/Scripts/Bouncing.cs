using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public Vector3 MovePos;
    public float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        // 规范化
        MovePos = new Vector3(1f, 1f).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // 碰撞到墙壁时，反弹
            transform.position += MovePos * _speed * Time.deltaTime;
        }
    }
}
