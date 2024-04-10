using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody rb;
    private bool walkForward = true;

    public Transform beginningRay;
    private Animator animator;

    private GameManager gameManager;

    public GameObject CrystalEffect;
    public GameObject CoinEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VeerOff();
        }

        RaycastHit contact;

        if (!Physics.Raycast(beginningRay.position, -transform.up, out contact, Mathf.Infinity))
        {
            animator.SetTrigger("Falling");
        }

        if(transform.position.y < -3)
        {
            gameManager.GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            animator.SetTrigger("GameStarted");
        }

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void VeerOff()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }

        walkForward = !walkForward;

        if (walkForward)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
    public AudioSource soundCoin;
    public AudioSource soundCrystal;
    public int scores;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            scores = 10;
            gameManager.IncreaseScore(scores);
            this.soundCoin.Play();
            GameObject g = Instantiate(CoinEffect, beginningRay.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
        else if(other.tag == "Crystal")
        {
            scores = 50;
            gameManager.IncreaseScore(scores);
            this.soundCrystal.Play();
            GameObject g = Instantiate(CrystalEffect, beginningRay.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
