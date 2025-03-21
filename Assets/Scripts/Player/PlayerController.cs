using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private float runningSpeed = 100f;
    private bool isFacingRight = true;

    private float hurtDuration = 0.25f;
    private float hurtCounter;

    [HideInInspector] public int lives = 3;
    [SerializeField] private GameObject heart;
    [SerializeField] private Sprite[] health;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runningSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runningSpeed;
        animator.SetFloat("horizontalSpeed", Mathf.Abs(horizontalMove));
        animator.SetFloat("verticalSpeed", verticalMove);
    }

    private void FixedUpdate() {
        if (lives > 0) {
            Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
        } else {
            // StartCoroutine(Die());
        }
    }

    private void Move(float moveX, float moveY) {
        if (hurtCounter <= 0) {
            animator.SetBool("isHurt", false);
            if (Math.Abs(moveX) > 0 && Math.Abs(moveY) > 0) {
                rb2d.linearVelocity = new Vector2(moveX * 3/4, moveY * 3/4);
            } else {
                rb2d.linearVelocity = new Vector2(moveX, moveY);
            }

            if (moveX < 0 && isFacingRight) {
		    	FlipThePlayer();
		    } else if (moveX > 0 && !isFacingRight) {
		    	FlipThePlayer();
		    }
        } else {
            animator.SetBool("isHurt", true);
            hurtCounter -= Time.fixedDeltaTime;
        }
    }

    private void FlipThePlayer() {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void HealthUpdate() {
		if (lives == 3) {
            heart.GetComponent<Image>().sprite = health[0];
        } else if (lives == 2) {
            heart.GetComponent<Image>().sprite = health[1];
        } else if (lives == 1) {
            heart.GetComponent<Image>().sprite = health[2];
        } else {
            heart.GetComponent<Image>().sprite = health[3];
        }
	}

    private IEnumerator Die() {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
