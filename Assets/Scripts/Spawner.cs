using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] prefab;
    public float minInterval = 1f;
    public float maxInterval = 3f;
	public Vector2 velocity = Vector2.left;
	public bool isComingFromLeft = false;

	// Use this for initialization
	void Start () {
		float randomInterval = Random.Range(minInterval, maxInterval);
		Invoke("SpawnNext", randomInterval);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void SpawnNext(){
		float randomInterval = Random.Range(minInterval, maxInterval);
		int randomIndex = Random.Range(0, prefab.Length);
		GameObject g = (GameObject)Instantiate(prefab[randomIndex], transform.position, Quaternion.identity);
		if (isComingFromLeft){
			g.transform.localScale = new Vector2(-1f, 1f); 
		}
		g.GetComponent<Rigidbody2D>().velocity = velocity;
		Invoke("SpawnNext", randomInterval);
	}
}
