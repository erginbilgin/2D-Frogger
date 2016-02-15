using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogController : MonoBehaviour {
	public const float stepDuration = 0.5f;
	private Coroutine playerMovement;
	public Animator animator;
	public float jumpSizeMultiplier = 1f;
	public bool isJumping = false;
	public AudioClip jumpSound;
	private AudioSource audioPlayer;
	public int playerScore = 0; 
	public Text scoreText;
	public Text highScoreText;
	public Text scoreOnPanel;
	public GameObject menuPanel;


	public int GetHighScore(){
		if(!PlayerPrefs.HasKey("Score")){
			PlayerPrefs.SetInt("Score",0);
    	}
    return PlayerPrefs.GetInt("Score");
    }
     
 	public void SetHighScore(int value){
    	PlayerPrefs.SetInt("Score",value);
    }

	private void Awake(){
		audioPlayer = GetComponent<AudioSource>();

	}

	private void Update()
	{
	    if (playerMovement == null)
	    {
	        if (Input.GetKey(KeyCode.W)){ 
				transform.rotation = Quaternion.Euler(0f,0f,0f);
	            playerMovement = StartCoroutine(Move(Vector2.up * jumpSizeMultiplier));
	            }
	        else if (Input.GetKey(KeyCode.S)){
				transform.rotation = Quaternion.Euler(0f,0f,180f);
	            playerMovement = StartCoroutine(Move(Vector2.down * jumpSizeMultiplier));
	            }
	        else if (Input.GetKey(KeyCode.D)){
				transform.rotation = Quaternion.Euler(0f,0f,270f);
	            playerMovement = StartCoroutine(Move(Vector2.right * jumpSizeMultiplier));
	            }
	        else if (Input.GetKey(KeyCode.A)){
				transform.rotation = Quaternion.Euler(0f,0f,90f);
	            playerMovement = StartCoroutine(Move(Vector2.left * jumpSizeMultiplier));
	            }
	    }
	}

	private IEnumerator Move(Vector2 direction){
	    Vector2 startPosition = transform.position;
	    Vector2 destinationPosition = (Vector2)transform.position + direction;
	    float t = 0.0f;
		animator.SetTrigger("Jump");
		isJumping = true;
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
	    playerScore++;
	    scoreText.text = playerScore.ToString();

	}

	void OnCollisionEnter2D(Collision2D coll) {
    	// HANDLE GAME OVER HERE
    	Destroy(gameObject);
	}


	void OnDestroy(){
		if (playerScore > GetHighScore()){
	    	SetHighScore(playerScore);
	    }
	    scoreOnPanel.text = playerScore.ToString();
		highScoreText.text = GetHighScore().ToString();
		menuPanel.SetActive(true);	
	}

}
