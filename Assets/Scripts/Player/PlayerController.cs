using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	private const float groundedRadius = 0.2f; // Radius of the overlap circle to determine if grounded
	private const float ceilingRadius = 0.2f; // Radius of the overlap circle to determine if the player can stand up
	[SerializeField]
    private float jumpForce = 400f;
    [Range(0, 1)] [SerializeField]
    private float crouchSpeed = 0.36f;
    [Range(0, .3f)] [SerializeField]
    private float movementSmoothing = 0.05f;
	[SerializeField]
	private bool isAirControl = false;
	[SerializeField]
	private LayerMask groundLayerMask;
	[SerializeField]
	private Transform goundCheck;
	[SerializeField] 
	private Transform ceilingCheck;
	[SerializeField]
	private Collider2D crouchDisableCollider;
	[SerializeField]
	private float runSpeed = 40f;

	private Rigidbody2D rigidBody2D;
	private Vector3 m_Velocity = Vector3.zero;
	private bool grounded;            // Whether or not the player is grounded.
	private bool jump;
	private bool wasCrouching = false;
	private bool facingRight = true;  // For determining which way the player is currently facing.		
	private float horizontalMove = 0f;

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;


	private PlayerStateController playerStateController;
    public PlayerStateController PlayerStateController { get => playerStateController; }

    private void Awake()
    {
        playerStateController = new PlayerStateController(this);
        rigidBody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

    private void Start()
    {
        
    }

    private void Update()
    {
        playerStateController.Update();
    }

    private void FixedUpdate()
    {
		PlayerStateController.FixedUpdate();
    }

    #region PlayerIdle
    public void InputCheck()
    {
        if(Input.anyKeyDown)
        {
            SetStateMove();
        }
    }
    #endregion

    #region PlayerMove
	public void MoveUpdate()
    {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		Debug.Log(horizontalMove);
		if(Input.GetButtonDown("Jump"))
        {
			jump = true;
		}
    }

	public void MoveFixedUpdate()
    {
		Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
    }
    public void Move(float move, bool crouch, bool jump)
    {
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, groundLayerMask))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (grounded || isAirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!wasCrouching)
				{
					wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= crouchSpeed;

				// Disable one of the colliders when crouching
				if (crouchDisableCollider != null)
					crouchDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (crouchDisableCollider != null)
					crouchDisableCollider.enabled = true;

				if (wasCrouching)
				{
					wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, rigidBody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (grounded && jump)
		{
			// Add a vertical force to the player.
			grounded = false;
			rigidBody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	#endregion

	#region SetState
	private void SetStateIdle()
    {
        playerStateController.ChangeState(PlayerIdle.Instance);
    }
    private void SetStateMove()
    {
        playerStateController.ChangeState(PlayerMove.Instance);
    }
    private void SetStateStop()
    {
        playerStateController.ChangeState(PlayerStop.Instance);
    }
    #endregion

}
