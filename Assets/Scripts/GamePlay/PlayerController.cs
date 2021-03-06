using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum AnimationStates {run=1,jump=2,death=3};
    public Player player;
    private Rigidbody2D rb2D;
    private Animator animator;
    public float jumpForce = 50;
    private bool playergrounded = true;
    bool up;
    float playerFall = 2.5f;
    // Start is called before the first frame update
    void Start()
    {

        rb2D = player.playerRigidBody;
        animator = player.PlayerAnimator;
       
    }
    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            up = false;
        }

    }

    private void FixedUpdate()
    {

        if (up)
        {
            if (playergrounded)
            {

                player.CurrentState = (int)AnimationStates.jump;
                // rb2D.AddForce(new Vector2(0, 500*speed*Time.deltaTime));
                rb2D.velocity = Vector2.up * jumpForce;
                if (rb2D.velocity.y < 0)
                {
                    rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerFall - 1) * Time.deltaTime;
                }
                playergrounded = false;
            }
        }


        ChangeState();
    }
    public void ChangeState()
    {
        animator.SetInteger("state", player.CurrentState);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playergrounded = true;
              player.CurrentState = (int)AnimationStates.run;
            ChangeState();
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.GameStart = false;
            GameManager.instance.gameComponents.gameStartCounter.gameObject.SetActive(true);
            GameManager.instance.gameComponents.gameStartCounter.text = "Game Over!";
            player.CurrentState = (int)AnimationStates.death;
            if (GameManager.scoreCount > GameManager.currentHighScore)
            {
                PlayerPrefs.SetInt("HighScore",GameManager.scoreCount);
            }
            GameManager.instance.gameComponents.replay.gameObject.SetActive(true);
            ChangeState();
            
            
        }
        if (collision.gameObject.tag == "Gem")
        {
            GameManager.gemCount++;
            GameManager.instance.gameComponents.gemCount.text = GameManager.gemCount + "";
            Destroy(collision.gameObject);

        }
    }
}
