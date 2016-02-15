using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
	public GameObject[] prefab;
	// 0. Road To Left
	// 1. Road To Right
	// 2. Water To Left
	// 3. Water To Right
	// 4. Grass
    public float interval = 0.5f;
	public Vector2 velocity = Vector2.left;
	private int lastIndex = 0;
	private int waterCount = 0;
	private int roadCount = 0;
	private int[][] spawnTable = new int[5][]{
		new int[]{1, 4},		// Nexts of 0
		new int[]{0, 4},		// Nexts of 1
		new int[]{4, 3},		// Nexts of 2
		new int[]{4, 2},		// Nexts of 3
		new int[]{0, 1, 2, 3}	// Nexts of 4
	};


	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnNext", 0, interval);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void SpawnNext(){
		
		int randomIndex = lastIndex;
		if (lastIndex == 0 && roadCount < 2){
			randomIndex = 1;
		} else if (lastIndex == 1 && roadCount < 2){
			randomIndex = 0;
		} else if (lastIndex == 2 && waterCount < 2){
			randomIndex = 3;
		} else if (lastIndex == 3 && waterCount < 2){
			randomIndex = 2;
		} else {
			randomIndex = spawnTable[lastIndex][Random.Range(0, spawnTable[lastIndex].Length)];
		}

		if (randomIndex == 0 || randomIndex == 1){
			roadCount++;
			waterCount = 0;
		}
		if (randomIndex == 2 || randomIndex == 3){
			waterCount++;
			roadCount = 0;
		}
		if (randomIndex == 4){
			waterCount = 0;
			roadCount = 0;
		}
		lastIndex = randomIndex;
		GameObject g = (GameObject)Instantiate(prefab[randomIndex], transform.position, Quaternion.identity);
	}
}
