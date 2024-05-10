using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyDrunkMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public int moveSpeed = 2;
    public int moveTime = 4;
    public int dir = 1;
    private bool facingRight = true;
    private Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextMove = moveSpeed;
        Invoke("Think", moveTime);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
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
        if(nextMove!=0)
        {
            nextMove = 0;
            animator.SetTrigger("isPause");
            Invoke("Think", moveTime/2);
        }
        else
        {
            dir *= -1;
            nextMove = moveSpeed * dir;
            animator.SetTrigger("isWalk");
            Flip();
            Invoke("Think", moveTime);
        }
        
    }
}