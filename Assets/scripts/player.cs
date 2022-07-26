using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D body;
    public float jumpSpeed;
    public SpriteRenderer sr;
    private Animator anim;
    float xInput;
    private bool grounded;

    //public gameover screen;

    [SerializeField]private AudioSource jumpSound;
    [SerializeField] private AudioSource deathSound;
    //[SerializeField] private AudioSource deathSound;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(xInput * moveSpeed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if(body.velocity.x > 0)
        {
            sr.flipX = false;
        }
        else if (body.velocity.x < 0) 
        {
            sr.flipX = true;
        }

        //animation
        anim.SetBool("run", xInput != 0);
        anim.SetBool("grounded", grounded);
    }

    //private bool isOnTheground()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, 0.2f);
    //    return hit.collider != null;
    //    
    //}
    
    private void Jump()
    {
        jumpSound.Play();
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        anim.SetTrigger("jump");
        grounded = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

        if(collision.gameObject.tag == "enemy")
        {

            deathSound.Play();
            //Destroy(gameObject);
            GameOver();
        }

        if(collision.gameObject.tag == "Finish")
        {
            end();
        }
    }

    public void GameOver()
    {

        SceneManager.LoadScene(2);
    }

    public void end()
    {
        SceneManager.LoadScene(3);
    }



}
