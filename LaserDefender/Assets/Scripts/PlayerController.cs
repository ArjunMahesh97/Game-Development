using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float minX; 
	float maxX;
	
	LevelManager level;
	public GameObject laser;
	public float laserSpeed = 5f;
	public float firingRate = 0.5f;
	public float health = 150f;

	public AudioClip playerLaser;

	public float speed = 15f;
	// Use this for initialization
	void Start () 
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX = leftmost.x + 1f;
		maxX = rightmost.x -1f;
	}
	
	void Fire()
	{
		GameObject beam = Instantiate(laser,transform.position + new Vector3(0,1f,0), Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,laserSpeed,0);
		AudioSource.PlayClipAtPoint(playerLaser,transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("Fire",0.000001f,firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("Fire");
		}
	
	
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp(transform.position.x,minX,maxX);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if(missile)
		{
			health -= missile.GetDamage();
			missile.hit();
			if(health<=0f)
			{
				Destroy(gameObject);
				Application.LoadLevel("End");
			}
		}
	}
	
}
