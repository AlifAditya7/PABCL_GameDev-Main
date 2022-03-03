using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float speed = -4f;
    [SerializeField] private LayerMask layerMask;

    Rigidbody2D rb2d;
    CircleCollider2D box2d;

    public string TagToIgnore = "Enemy1";
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<CircleCollider2D>();
        rb2d.velocity = new Vector2(speed, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }

        if (isGrounded())
        {
            GameManager._instance.swordSwingSfxOn();
        }

        else
        {
            GameManager._instance.swordSwingSfxOff();
        }
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
