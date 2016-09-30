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

	// snake
	public GameObject snake;

	// Use this for initialization
	void Start () {
		// Spawn food every 4 seconds, starting in 3
		InvokeRepeating("Spawn", 3, 4);
	}

	void Update() {

		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("I clicked somewhere");
			// get position of click
			Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (clickPosition);

			// Check where the snake is standing and going
			Vector2 snakePosition = snake.transform.position;
			Vector2 snakeDirection = snake.GetComponent<Snake>().direction;

			// Check if you are going vertically or horizontally
			// snake is going left or right
			if (snakeDirection == Vector2.right || snakeDirection == Vector2.left) {
				// click above the snake to go up
				if (snakePosition.y < clickPosition.y) {
					snake.GetComponent<Snake> ().direction = Vector2.up;
				} // click below the snake to go down
				else {
					snake.GetComponent<Snake> ().direction = Vector2.down;
				}
			} // snake is going up or down
			else {
				// click right the snake to go right
				if (snakePosition.x < clickPosition.x) {
					snake.GetComponent<Snake> ().direction = Vector2.right;
				} // click left of the snake to go left
				else {
					snake.GetComponent<Snake> ().direction = Vector2.left;
				}
			}
		}
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
