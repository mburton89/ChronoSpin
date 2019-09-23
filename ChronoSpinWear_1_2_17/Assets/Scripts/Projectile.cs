using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour, ITakeDamage{
	
	//public GameObject fastPaddle;
	public GameObject Owner { get; private set;}
	public Vector2 Direction { get; set;}
	public Vector2 Velocity { get; private set;}
	public int IsClockwise { get; private set;}
	public LayerMask CollisionMask;
	//public ProjectileDispenser projectileDispenser;
	public Background background;
	public GameManager gameManager;
	//public FiringPatterns patterns;
	public SpinningLine line;
	//private static System.Random random = new System.Random();
	
	public float Speed;
	public float timeToLive;
	public int damage;
	public int pointsToGiveToPlayer;
	public bool isActive {get; set;}
	public bool isDeflected{get; set;}

	public Animator Animator;

	public AudioClip GameOverSound;
	
	public void Start () {
//		projectileDispenser = FindObjectOfType<ProjectileDispenser> ();
//		patterns = FindObjectOfType<FiringPatterns> ();
		//line = FindObjectOfType<SpinningLine> ();
		//background = FindObjectOfType<Background> ();
		gameManager = FindObjectOfType<GameManager> ();    
		//isActive = true;
		//transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45 , transform.rotation.w);
	}
	
	void Update () {

		if(transform.position.y < -6){ // || transform.position.x > 15){
			Destroy(gameObject);
			return;
		}
				
		transform.Translate ((Direction + new Vector2 (Velocity.x, Velocity.y)) * Speed * Time.deltaTime, Space.World);
		//determineSpinningSpeed();
		//isActive = true;
	}
	
	public void TakeDamage(int damage, GameObject instigator){
		destroyProjectile ();
	}

	public void Initialize(GameObject owner, Vector2 direction, Vector2 velocity){
		transform.up = direction;
		Owner = owner;
		Direction = direction; 
		Velocity = velocity; 
		OnInitialized();
		//transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45 , transform.rotation.w);
		
	}

	public void Initialize(GameObject owner, Vector2 direction, Vector2 velocity, int isClockwise){
		transform.up = direction;
		Owner = owner;
		Direction = direction; 
		Velocity = velocity;  
		IsClockwise = isClockwise;
		OnInitialized();
		//transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45 , transform.rotation.w);
		   
	}
	
	protected virtual void OnInitialized(){
		return;
	}
	
	public virtual void OnTriggerEnter2D(Collider2D other){
		
		if((CollisionMask.value & (1 << other.gameObject.layer)) == 0){
			OnNotCollideWith(other);
			return;
		}
		OnCollideOther(other);
	}
	
	protected virtual void OnNotCollideWith(Collider2D other){
		if(other.name == "Line"){     
			Speed = 0;  
			Time.timeScale = 1f;
			gameManager.displayGameOverScreen();    
		}
	}

	public void flicker(){
		StartCoroutine(initiateFlickerCo());
	}
		
	private IEnumerator initiateFlickerCo(){
		float waitTime = .03f * (Time.timeScale/1);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("CircleP", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("CircleP", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("CircleP", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("CircleP", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
	}
	
	protected virtual void OnCollideOwner(Collider2D other, ITakeDamage takeDamage){

	}
	
	protected virtual void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage){
		destroyProjectile();
	}
	
	public void OnCollideOther(Collider2D other){      
 
	} 
	
	private void destroyProjectile(){
		Destroy(gameObject);   
	}
	
	private void ResetGame(){
		destroyProjectile();
	}

	private void endSession(){
		AudioSource.PlayClipAtPoint(GameOverSound, transform.position);
		GameManager.Instance.ResetPointsToZero();
	}

	public void determineSpinningSpeed(){
		transform.Rotate(0, 0, (line.spinningSpeed * -IsClockwise)* Time.deltaTime,Space.Self);
	}
}