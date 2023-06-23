using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 10f;
    [SerializeField]
    public float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "isWalking";
    private bool isGrounded =true;

    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk();
        AnimatePlayer();
        PlayerJump();
    }
    void PlayerWalk(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX , 0f , 0f) *Time.deltaTime * moveForce ;
    }
    void AnimatePlayer(){
        if(movementX>0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=false;
        }else if(movementX<0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=true;
        }else{
            anim.SetBool(WALK_ANIMATION,false);
        }
    }
    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded=false;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("ground")){
            isGrounded = true;
        }
    }
}
