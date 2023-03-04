using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] HitCheckCollisionManager hitChecker;
    StageHitChecker stageHit;


    [Header("Movement")]
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    // flags
    bool isJumping;

    // proparties
    public SpriteRenderer Rend => rend;

	//--------------------------------------------------

	private void Start()
	{
        stageHit = hitChecker.GetHitChecker<StageHitChecker>();
	}

	void Update()
    {
        // jump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            rb.AddForce(Vector2.up * jumpForce);
		}

        // move
        var x = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * x * moveSpeed);

        // jumpingFlag
        isJumping = !stageHit.IsHit;
    }
}
