using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class character_move : MonoBehaviour
{
    public float speed,jump_speed;

    private float moveInputX;
    private float moveInputY;
    private bool facingRight = true;

    public bool grounded;
    public bool isJump = false;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY =  Input.GetAxisRaw ("Vertical");
        rb.velocity = new Vector2(moveInputX * speed, rb.velocity.y);

        if (moveInputX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInputX < 0 && facingRight)
        {
            Flip();
        }
        
        jump();

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void jump()
    {
        if (Input.GetKeyDown (KeyCode.Space) ){
                    if(!isJump)
                    {
                        isJump = true;
                        rb.velocity = new Vector2(rb.velocity.x, jump_speed);
                    }
                 } 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("aa");
      //check if the collsion is happening with a game object with "ground" tag.
        if (other.gameObject.tag.Equals("ground")){
            isJump = false;
            Debug.Log("isJump : false 정상 작동 중");
        }

        if (other.gameObject.tag.Equals("vote_paper")){
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
    }

    

    
}