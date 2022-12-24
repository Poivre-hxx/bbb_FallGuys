using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "InGame")
        {
            // ��⵽����bdr�����л���"ending"
            if (Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }

    public void LoginSceneChange()
    {
        
        SceneManager.LoadScene("InGame");
    }


}
