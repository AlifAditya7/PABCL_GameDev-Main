using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask layerMask;

    Rigidbody2D rb2d;
    CircleCollider2D box2d;
    Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            GameManager._instance.ShowGameOver();
        }
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            Debug.Log("Hit Enemy");
            GameManager._instance.ShowGameOver();
        }
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

   
    private void Update()
    {
        if (transform.position.y <= -10)
        {
            GameManager._instance.ShowGameOver();
        }

        if (Input.GetKey(KeyCode.Z) && isGrounded())
        {
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            GameManager._instance.jumpSfxOn();
            GameManager._instance.stepSfxOff();
        }
        else if (isGrounded())
        {
            GameManager._instance.jumpSfxOff();
            GameManager._instance.stepSfxOn();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager._instance.ShowMainMenu();
        }

        animator.SetFloat("velY", rb2d.velocity.y);
        animator.SetBool("isGround",isGrounded());

    }

    private bool isGrounded()
    {
        float extra = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(box2d.bounds.center, Vector2.down, box2d.bounds.extents.y + extra, layerMask);

        // Debug purpose
        Color rayColor;
        if (raycastHit.collider is null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(box2d.bounds.center, Vector2.down * (box2d.bounds.extents.y + extra), rayColor);

        return raycastHit.collider != null;
    }
}

