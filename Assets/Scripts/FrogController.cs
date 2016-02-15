using UnityEngine;using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class FrogController : MonoBehaviour {
	public const float stepDuration = 0.5f;
	public Coroutine playerMovement;
	public Animator animator;
	public float jumpSizeMultiplier = 1f;
	public bool isJumping = false;
	public AudioClip jumpSound;
	private AudioSource audioPlayer;
	public int playerScore = 0; 
	public Text scoreText;
	public GameObject menuPanel;
	public static bool isGameActive = true;
	public string frogName = "Kermit";


	private void Awake(){
		audioPlayer = GetComponent<AudioSource>();

	}

	protected virtual void Start(){
		isGameActive = true;

	}

	public bool IsGameActive(){ return isGameActive; }

	public void MoveUp(){
		transform.rotation = Quaternion.Euler(0f,0f,0f);
	    playerMovement = StartCoroutine(Move(Vector2.up * jumpSizeMultiplier));
	}
	public void MoveDown(){
		transform.rotation = Quaternion.Euler(0f,0f,180f);
	    playerMovement = StartCoroutine(Move(Vector2.down * jumpSizeMultiplier));
	}
	public void MoveRight(){
		transform.rotation = Quaternion.Euler(0f,0f,270f);
	    playerMovement = StartCoroutine(Move(Vector2.right * jumpSizeMultiplier));
	}
	public void MoveLeft(){
		transform.rotation = Quaternion.Euler(0f,0f,90f);
	    playerMovement = StartCoroutine(Move(Vector2.left * jumpSizeMultiplier));
	}

	private void Update()
	{
	    
	}



	private IEnumerator Move(Vector2 direction){
	    Vector2 startPosition = transform.position;
	    Vector2 destinationPosition = (Vector2)transform.position + direction;
	    float t = 0.0f;
		animator.SetTrigger("Jump");
		isJumping = true;
		GetComponent<FrogController>().isJumping = true;
		audioPlayer.PlayOneShot(jumpSound, 1F);
	    while (t < 1.0f)
	    {
	        transform.position = Vector2.Lerp(startPosition, destinationPosition, t);
	        t += Time.deltaTime / stepDuration;
	        yield return new WaitForEndOfFrame();
	    }

	    transform.position = destinationPosition;
	    playerMovement = null;
	    isJumping = false;
		GetComponent<FrogController>().isJumping = false;
	    playerScore++;
	    scoreText.text = playerScore.ToString();

	}

	void OnCollisionEnter2D(Collision2D coll) {
    	// HANDLE GAME OVER HERE
    	Destroy(gameObject);
	}


	protected virtual void OnDestroy(){
		menuPanel.SetActive(true);
		isGameActive = false;	
	}

}

