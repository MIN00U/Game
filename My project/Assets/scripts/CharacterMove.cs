using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class character_move : MonoBehaviour
{
    public float speed,jump_speed;

    private float moveInputX;
    private float moveInputY;
    private bool facingRight = true;

    private bool isGodLike = false; //데미지 받은 후 잠깐 무적 판정

    private bool grounded;
    private bool isJump = false;
    private bool timeOver = false;

    public string SceneToLoad;

    public TextMeshProUGUI scoreText;
    private SpriteRenderer spriteRenderer;
    static int score = 0;

    public AudioSource audioSource;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource.mute = false;

// 루핑: true일 경우 반복 재생
audioSource.loop = true;

    }

    private void Update()
    {

        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY =  Input.GetAxisRaw ("Vertical");

        if(!timeOver) {
            rb.velocity = new Vector2(moveInputX * speed, rb.velocity.y);
            if (moveInputX > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveInputX < 0 && facingRight)
            {
                Flip();
            }
        
            Jump();
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Jump()
    {
        if (Input.GetKeyDown (KeyCode.Space) ){
                    if(!isJump)
                    {
                        isJump = true;
                        rb.velocity = new Vector2(rb.velocity.x, jump_speed);
                    }
                 } 
    }

    public void TimeOver() {
        timeOver = true;
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("vote_paper")){
                Destroy(other.gameObject);
                score++;
                scoreText.text = score.ToString();
            }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("aa");
      //check if the collsion is happening with a game object with "ground" tag.
        if (other.gameObject.tag.Equals("ground")){
            if (other.gameObject.transform.position.y<transform.position.y) {
                isJump = false;
            }
            Debug.Log("isJump : false 정상 작동 중");
        }
        if (other.gameObject.tag.Equals("enemy"))
        {
            if (!isGodLike)
            {
                isGodLike = !isGodLike;
                Invoke("notGodLike", 3);
                spriteRenderer.color = new Color(1, 1, 1, 0.5f);
                score = score<=0 ? 0 : score-1;

                scoreText.text = score.ToString();
            }
        }
        if (other.gameObject.tag.Equals("checkpoint")){
            StaticData.valueToKeep = score;
            Debug.Log("넘어가기 전 score" + score.ToString());
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    private void notGodLike()
    {
        isGodLike = !isGodLike;
        spriteRenderer.color = new Color(1, 1, 1, 1); //무적 타임 종료(원래대로)
    }

    
}