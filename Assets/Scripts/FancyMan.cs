using System;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class FancyMan : MonoBehaviour
{
	float MoveF = 10f, JumpF = 20f, WallF = 100f;
	string RUN_ANIM = "Run", JUMP_ANIM = "Jump", GROUND_TAG = "Ground";
	float MoveX;
	float maxVel = 15f;

	SpriteRenderer render;
	[SerializeField] Rigidbody2D body;
	[SerializeField] LayerMask groundLayer;
	Animator anim;
	[SerializeField] GameObject groundCheck;
	[SerializeField] GameObject wallCheck;

	private void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		render = GetComponent<SpriteRenderer>();
		
		body.gravityScale = 5f;
	}

	// Update is called once per frame

	private void Update()
	{

	}

	void LateUpdate()
	{
		if (!PauseMenu.paused)
		{
			PlayerMoveKeyboard();
			AnimatePlayer();
			if (Input.GetButtonDown("Jump"))
			{
				PlayerJump();
				WallJump();
			}
		}
		else
			anim.SetBool(RUN_ANIM, false);
	}

	void PlayerMoveKeyboard()
	{
		MoveX = Input.GetAxis("Horizontal");
		if (MoveX != 0 && isGrounded())
			body.velocity = new Vector2(MoveX * MoveF, body.velocity.y);
		else
		{
			var airF = MoveX * MoveF / 10;
			body.velocity = new Vector2(Mathf.Clamp(body.velocity.x + airF, -maxVel, maxVel), body.velocity.y);
		}
	}

	void AnimatePlayer()
	{
		if(MoveX > 0) // move right
		{
			anim.SetBool(RUN_ANIM, true);
			render.flipX = false;
			wallCheck.transform.position = new Vector3(gameObject.transform.position.x + 0.14f, 
										   wallCheck.transform.position.y, wallCheck.transform.position.z);
		}
		else if(MoveX < 0) // move left
		{
			anim.SetBool(RUN_ANIM, true);
			render.flipX = true;
			wallCheck.transform.position = new Vector3(gameObject.transform.position.x - 0.14f, 
										   wallCheck.transform.position.y, wallCheck.transform.position.z);	
		}
		else
			anim.SetBool(RUN_ANIM, false);
		if(!isGrounded())
			anim.SetBool(JUMP_ANIM, true);
		else
			anim.SetBool(JUMP_ANIM, false);
	}

	bool isGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundLayer);
	}

	bool isWalled()
	{
		return Physics2D.OverlapCircle(wallCheck.transform.position, 0.2f, groundLayer);
	}

	void PlayerJump()
	{
		if(!isGrounded())
			return;
		body.velocity = new Vector2(body.velocity.x, JumpF);
	}

	void WallJump()
	{
		if (isGrounded() || !isWalled())
			return;
		if (render.flipX)
			body.velocity += new Vector2(WallF, WallF/2);
		else
			body.velocity += new Vector2(-WallF, WallF/2);
		
	}
	
	Vector3 validUp = Vector3.up;
	float contactThreshold = 10; // Acceptable slant

	//private void OnCollisionStay2D(Collision2D collision)
	//{
	//	if (!collision.gameObject.CompareTag(GROUND_TAG))
	//		return;
	//	float contactAngle;
	//	for (int i = 0; i < collision.contacts.Length; i++)
	//	{
	//		contactAngle = Vector3.Angle(collision.contacts[i].normal, validUp);
	//		if (contactAngle == 90 && !isGrounded)
	//		{
	//			wallJump = true;
	//			continue;
	//		}
	//		else if (contactAngle > contactThreshold)
	//			continue;
	//		isGrounded = true;
	//		anim.SetBool(JUMP_ANIM, false);
	//		break;
	//	}
	//}

	//private void OnCollisionExit2D(Collision2D collision)
	//{
	//	if (!collision.gameObject.CompareTag(GROUND_TAG))
	//		return;
	//	wallJump = false;
	//	isGrounded = false;
	//}
}//class
