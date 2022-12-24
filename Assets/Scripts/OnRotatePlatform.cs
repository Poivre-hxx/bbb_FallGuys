using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRotatePlatform : MonoBehaviour
{
    // 遇上旋转平台
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    // 遇到出口
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }
    }
}
