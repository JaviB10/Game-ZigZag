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
}
