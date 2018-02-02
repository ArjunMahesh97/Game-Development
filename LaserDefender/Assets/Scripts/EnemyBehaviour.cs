using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject projectile;
	public GameObject explosion;
	public float missileSpeed = -5f;
	public float health = 50f;
	public float shotsPerSec = 0.5f;
	public int scoreValue = 50;
	
	private GameObject expln;
	
	public AudioClip enemyLaser,death;
	
	
	private IEnumerator coroutine;
	private ScoreKeeper score;

	void Start()
	{
		score = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update()
	{
		float probability = Time.deltaTime * shotsPerSec;
		if(Random.value <= probability)
		{
			Fire();
		}		
	}
	
	void Fire()
	{
		GameObject missile = Instantiate(projectile,transform.position + new Vector3(0, -1f,0), Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0,missileSpeed,0);
		AudioSource.PlayClipAtPoint(enemyLaser,transform.position);
	}


	public void OnTriggerEnter2D(Collider2D col)
	{
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if(missile)
		{
			health -= missile.GetDamage();
			missile.hit();
			if(health<=0f)
			{
				Destroy(gameObject);
				score.Score(scoreValue);
				AudioSource.PlayClipAtPoint(death,transform.position);	
				expln = Instantiate(explosion,transform.position, Quaternion.identity) as GameObject;
				expln.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
				Destroy(expln,1.0f);
				//coroutine = Done (2f);
				//StartCoroutine(coroutine);						
			}
		}
	}
	
	//IEnumerator Done(float wait)
	//{
	//	yield return new WaitForSeconds(wait);
	//	Destroy(gameObject);
	//}
}