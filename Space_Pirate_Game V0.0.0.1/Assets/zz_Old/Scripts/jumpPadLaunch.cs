using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPadLaunch : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float launchSpeed;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("startJumpPad");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = new Vector2(rb.velocity.x, launchSpeed);
    }



}
