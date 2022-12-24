using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] float spawnValue;
    [SerializeField] GameObject player;

    [SerializeField] Transform respawnPoint;

    Animator anim;

    private RaycastHit hit;
    private int layerMask;
    public float distance = 10;
    AudioSource resp;

    void Awake()
    {
        anim = player.GetComponentInChildren<Animator>();
        layerMask = 1 << 7;
        resp = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(player.transform.position, -player.transform.up, out hit, distance, layerMask))
        {
            //RespSound();
            DownPlayer();
            resp.Play();
        }
    }

    void DownPlayer()
    {
        anim.SetBool("isFalling", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isFalling", false);

            player.transform.position = respawnPoint.transform.position;
        }
    }
}
