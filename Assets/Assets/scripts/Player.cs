using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private float jumpforce=5.0f;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private LayerMask groundLayer;
    private PlayerAnimation anim;
    private SpriteRenderer sprite;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim =  GetComponent<PlayerAnimation>();
        sprite= GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();    
    }
    bool isgrounded(){
        RaycastHit2D hitifo = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, groundLayer.value);
        UnityEngine.Debug.DrawRay(transform.position, Vector2.down * 0.2f, Color.green);
        if (hitifo.collider != null)
            return true;
        else
            return false;
    }
    void movement(){
        float move = Input.GetAxisRaw("Horizontal");
        flip(move);
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpforce);
        }
        rigid.velocity = new Vector2(move*speed, rigid.velocity.y);
        anim.move(move);
    }
    void flip(float move){
        if(move>0){
            sprite.flipX=false;
        }
        else if(move<0){
            sprite.flipX=true;
        }
    }
}
