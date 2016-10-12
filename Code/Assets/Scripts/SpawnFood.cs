using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	// food prefab
	public GameObject food;

	// borders
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;

	// Use this for initialization
	void Start () {
		// Three apples in the beginning
		Spawn();
		Spawn();
		Spawn();

		// Spawn food every 4 seconds, starting in 3
		InvokeRepeating("Spawn", 3, 4);
	}

	void Spawn() {
		// x position between left & right border
		int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

		// y position between top & bottom border
		int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

		// Instantiate the food at (x, y)
		Instantiate(food, new Vector2(x, y), Quaternion.identity);
	}
}
