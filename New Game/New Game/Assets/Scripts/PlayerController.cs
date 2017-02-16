using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController sharedInstance;

	public float runSpeed = 10.0f;
	public float jumpForce = 6.0f;
	private Rigidbody2D rigiBody;
	public LayerMask groundLayerMask;
	public Animator animator;

	private Vector3 startPosition;

	void Awake (){
		animator.SetBool ("isAlive", true);

		sharedInstance = this;
		rigiBody = GetComponent<Rigidbody2D>();
		startPosition = this.transform.position;

	}

	// Use this for initialization
	public void StartGame () {
		animator.SetBool ("isAlive", true);
		this.transform.position = startPosition;
		rigiBody.velocity = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.sharedInstance.currentGameStates == GameState.inTheGame) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Jump ();
			}

			animator.SetBool ("isGrounded", IsOnTheFloor ());
		}
	}

	void FixedUpdate (){
		if (GameManager.sharedInstance.currentGameStates == GameState.inTheGame) {
			if (rigiBody.velocity.x < runSpeed) {
				rigiBody.velocity = new Vector2 (runSpeed, rigiBody.velocity.y);
			}

		}
	}

	void Jump(){
		if (IsOnTheFloor()) {
			rigiBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	bool IsOnTheFloor(){
		if (Physics2D.Raycast (this.transform.position, Vector2.down, 1.0f	, groundLayerMask.value)) {
			return true;
		}else{
			return false;
	}
}

	public void KillPlayer(){
		GameManager.sharedInstance.currentGameStates = GameState.gameOver;
		animator.SetBool ("isAlive", false);
	}

		}