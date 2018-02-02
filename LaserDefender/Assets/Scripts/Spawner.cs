using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;	
	public float speed = 3f;
	public float delay = 0.5f;
	
	private bool movingRight = true;
	
	private float minX; 
	private float maxX;
	
	
	// Use this for initialization
	void Start () {
				
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX = leftmost.x;
		maxX = rightmost.x;
		
		spawn ();
	
	}
	
	void spawn()
	{
		foreach( Transform child in transform)
		{
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position , Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
			
		}
	}
	
	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
	}
	
	void Update()
	{
		if(movingRight)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}	
		else
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}	
		
		float rightEdge = transform.position.x + (0.5f*width);
		float leftEdge = transform.position.x - (0.5f*width);
		if(leftEdge < minX)
		{
			movingRight = true;
		}
		else if(rightEdge > maxX)
		{
			movingRight = false;
		}
		
		if(AllMembersDead())
		{
			SpawnUntilFull();
		}
	}
	
	Transform NextFree()
	{
		foreach(Transform child in transform)
		{
			if(child.childCount == 0)
			{
				return child;
			}
		}
		return null;
	}
	
	void SpawnUntilFull()
	{
		Transform free = NextFree();
		if(free)
		{
			GameObject enemy = Instantiate(enemyPrefab, free.position , Quaternion.identity) as GameObject;
			enemy.transform.parent = free;
		}
		if(NextFree())
		{	
			Invoke("SpawnUntilFull",delay);
		}
	}
	
	bool AllMembersDead()
	{
		foreach(Transform child in transform)
		{
			if(child.childCount > 0)
			{
				return false;
			}
		}
		return true;
	}
	
}
