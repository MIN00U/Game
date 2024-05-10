using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyProtestMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public int walkSpeed = 1;
    public int runSpeed = 3;
    public int moveTime = 4;
    public int dir = 1;
    GameObject player;
    private bool facingRight = true;
    private Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextMove = walkSpeed;
        Invoke("Think", moveTime);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 7)
        {
            nextMove = runSpeed * dir;
            animator.SetTrigger("isRun");
        }
        else
        {
            nextMove = walkSpeed * dir;
            animator.SetTrigger("isWalk");
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Think()
    {
        dir *= -1;
        nextMove *= -1;
        Flip();
        Invoke("Think", moveTime);      
    }
}