using Unity.VisualScripting;
using UnityEngine;

public class FancyMan : MonoBehaviour
{
	[SerializeField]
	float MoveF = 10f, JumpF = 11f;
	string RUN_ANIM = "Run", JUMP_ANIM = "Jump", GROUND_TAG = "Ground";
	float MoveX;
	float VelY;
	bool isGrounded;

	SpriteRenderer Render;
	[SerializeField]
	Rigidbody2D Body;
	Animator Anim;

	private void Awake()
	{
		Body = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator>();
		Render = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame

	private void Update()
	{
		if (!PauseMenu.paused)
		{
			VelY = Body.velocity.y;
			Debug.Log(VelY);
		}
	}

	void LateUpdate()
	{
		if (!PauseMenu.paused)
		{
			if (VelY != 0)
				isGrounded = false;
			PlayerMoveKeyboard();
			AnimatePlayer();
			PlayerJump();
		}
		else if (PauseMenu.paused)
		{
			Anim.SetBool(RUN_ANIM, false);
		}
	}

	void PlayerMoveKeyboard()
	{
		MoveX = Input.GetAxis("Horizontal");
		transform.position += new Vector3(MoveX, 0f, 0f) * Time.deltaTime * MoveF;
	}

	void AnimatePlayer()
	{
		if(MoveX > 0) // move right
		{
			Anim.SetBool(RUN_ANIM, true);
			Render.flipX = false;
		}
		else if(MoveX < 0) // move left
		{
			Anim.SetBool(RUN_ANIM, true);
			Render.flipX = true;
		}
		else
			Anim.SetBool(RUN_ANIM, false);
		if(VelY != 0)
			Anim.SetBool(JUMP_ANIM, true);
		else
			Anim.SetBool(JUMP_ANIM, false);
	}

	void PlayerJump()
	{
		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			isGrounded = false;
			Body.AddForce(new Vector2(0f, JumpF), ForceMode2D.Impulse);
			Anim.SetBool(JUMP_ANIM, true);
		}	
	}
	
	Vector3 validUp = Vector3.up;
	[SerializeField]
	float contactThreshold; // Acceptable slant

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag(GROUND_TAG))
		{
			for (int i = 0; i < collision.contacts.Length; i++)
			{
				if (Vector3.Angle(collision.contacts[i].normal, validUp) <= contactThreshold)
				{
					isGrounded = true;
					break;
				}
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		isGrounded = false;
	}
}//class
