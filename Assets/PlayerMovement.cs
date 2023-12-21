using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class LockRotation : MonoBehaviour
// {
//     private Rigidbody rb;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         rb.constraints = RigidbodyConstraints.FreezeRotationZ;
//     }
//     void Update()
//     {
//         rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, 0f);
//     }
// }


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        dirX  = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*7f , rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, 14f);
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
    if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);

        }
    }
}
