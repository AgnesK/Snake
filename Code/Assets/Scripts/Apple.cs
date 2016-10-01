using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	const int dist = 3;
	// distance at which apples start moving

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Snake snake = Snake.getInstance();
		//float x = 1 / 0;

		// Run away from the snake ^_^
		if (snake.transform.position.y == this.transform.position.y &&
			((snake.transform.position.x == this.transform.position.x + dist && snake.direction == Vector2.left) ||
			 (snake.transform.position.x == this.transform.position.x - dist && snake.direction == Vector2.right))) {
			if (Random.value > 0.5) {
				this.transform.Translate(Vector2.up);
			} else {
				this.transform.Translate(Vector2.down);
			}
		}
		if (snake.transform.position.x == this.transform.position.x &&
			((snake.transform.position.y == this.transform.position.y + dist && snake.direction == Vector2.down) ||
			 (snake.transform.position.y == this.transform.position.y - dist && snake.direction == Vector2.up))) {
			if (Random.value > 0.5) {
				this.transform.Translate(Vector2.left);
			} else {
				this.transform.Translate(Vector2.right);
			}
		}
	}
}
