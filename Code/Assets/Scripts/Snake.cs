using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

	// Current Movement Direction
	// (by default it moves to the right)
	public Vector2 direction = Vector2.right;
	public float movementSpeed;

	// Singleton
	static private Snake instance = null;
	static public Snake getInstance() {
		return Snake.instance;
	}

	// Keep Track of Tail
	List<Transform> tail = new List<Transform>();

	// Did the snake eat something?
	bool ate = false;

	// Tail Prefab
	public GameObject tailPrefab;

	// Use this for initialization
	void Start () {
		Snake.instance = this;
		InvokeRepeating ("Move", 0.05f, movementSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		// Move in a new Direction?
		if (Input.GetKey (KeyCode.RightArrow))
			direction = Vector2.right;
		else if (Input.GetKey (KeyCode.DownArrow))
			direction = Vector2.down;
		else if (Input.GetKey (KeyCode.LeftArrow))
			direction = Vector2.left;
		else if (Input.GetKey (KeyCode.UpArrow))
			direction = Vector2.up;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// Food?
		if (collider.name.StartsWith ("Food")) {
			// Get longer in next Move call
			ate = true;

			// Remove the Food
			Destroy (collider.gameObject);
		} 
		// Collided with tail or Border
		else {
			// ToDo 'You lose' screen
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	void Move() {
		// Save current position of head
		Vector2 lastHeadPosition = transform.position;

		// Move head into new direction
		transform.Translate(direction);

		// Ate something? Then insert new Element into gap
		if (ate) {
			// Load Prefab into the world
			GameObject snakeAppendix = (GameObject)Instantiate (tailPrefab, lastHeadPosition, Quaternion.identity);

			// Keep track of it in our tail list
			tail.Insert (0, snakeAppendix.transform);

			// Reset the flag
			ate = false;
		}
		// Do we have a Tail?
		else if (tail.Count > 0) {
			// Move last Tail Element to where the Head was
			tail.Last ().position = lastHeadPosition;

			// Add to front of list, remove from the back
			tail.Insert (0, tail.Last ());
			tail.RemoveAt (tail.Count - 1);
		}
	}
}
