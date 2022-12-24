using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int countdownTime = 5;

    public Text countdownDisplay;
    public GameObject anim;

    public GameObject Num_1; //1
    public GameObject Num_2; //2
    public GameObject Num_3; //3
    public GameObject Num_GO; //go

    Animator animator;

    public AudioSource mysfx;
    public AudioClip startsfx;
    public AudioClip gosfx;

    private void Awake()    
    {
        animator = anim.GetComponent<Animator>();
        StartCoroutine(CountdownToStart()); // 开通子线程

        Num_1.SetActive(false);
        Num_2.SetActive(false);
        Num_3.SetActive(false);
        Num_GO.SetActive(false);

        Time.timeScale = 0;
    }

    // 开通子线程 CountdownToStart()
    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            ChangeImage();
            countdownDisplay.text = countdownTime.ToString();
            
            yield return new WaitForSecondsRealtime(1f) ; // 中断线程1s
            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        Time.timeScale = 1;

        yield return new WaitForSecondsRealtime(1f); // 中断线程1s

        countdownDisplay.gameObject.SetActive(false);
    }

    void ChangeImage()
    {
        switch (countdownTime)
        {
            case 4:
                Num_3.SetActive(true);
                animator.SetBool("Num3", true);
                mysfx.PlayOneShot(startsfx);
                break;
            case 3:
                Num_2.SetActive(true);
                animator.SetBool("Num3", true);
                mysfx.PlayOneShot(startsfx);
                break;
            case 2:
                Num_1.SetActive(true);
                animator.SetBool("Num3", true);
                mysfx.PlayOneShot(startsfx);
                break;
            case 1:
                Num_GO.SetActive(true);
                animator.SetBool("Num3", true);
                mysfx.PlayOneShot(gosfx);
                break;
        }
    }
}
