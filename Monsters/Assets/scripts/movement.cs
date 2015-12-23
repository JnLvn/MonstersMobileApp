using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	Transform player;

	public float speed;
	Vector2 destination = Vector2.zero;
	
	// Use this for initialization
	void Start () {
		destination = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Move towards destination
		Vector2 pos = Vector2.MoveTowards (transform.position, destination, speed);
		// Get component gets the rigidbody component on the hero and moves it by pos
		GetComponent<Rigidbody2D>().MovePosition(pos);


		// Movement for webplayer
		// Check for Input if not moving
		if ((Vector2)transform.position == destination) {
			if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up)){
				pos.y += speed * Time.deltaTime;
				transform.position = pos;
				destination = (Vector2)transform.position + Vector2.up;
			}
			if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right)){
				destination = (Vector2)transform.position + Vector2.right;
				pos.x += speed * Time.deltaTime;
				transform.position = pos;
			}
			if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up)){
				destination = (Vector2)transform.position - Vector2.up;
				pos.y -= speed * Time.deltaTime;
				transform.position = pos;
			}
			if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right)){
				destination = (Vector2)transform.position - Vector2.right;
				pos.x -= speed * Time.deltaTime;
				transform.position = pos;
			}
		}

		
		// Movement for touchscreen phone
		if ((Vector2)transform.position == destination) {
			if(Input.touchCount > 0){
				Touch myTouch = Input.touches[0];

				if(myTouch.phase == TouchPhase.Stationary){
					if(myTouch.position.x > Screen.width/2 && valid(Vector2.right)){
						pos.x += speed * Time.deltaTime;
						transform.position = pos;
						destination = (Vector2)transform.position + Vector2.right;
					}
					if(myTouch.position.x < Screen.width/2 && valid(Vector2.left)){
						pos.x -= speed * Time.deltaTime;
						transform.position = pos;
						destination = (Vector2)transform.position + Vector2.left;
					}
					if(myTouch.position.y > Screen.height/2 && valid(Vector2.up)){
						pos.y += speed * Time.deltaTime;
						transform.position = pos;
						destination = (Vector2)transform.position + Vector2.up;
					}
					if(myTouch.position.y < Screen.height/2 && valid(Vector2.down)){
						pos.y -= speed * Time.deltaTime;
						transform.position = pos;
						destination = (Vector2)transform.position + Vector2.down;
					}
				}
			}
		}

			
		// Animation Parameters
		Vector2 dir = destination - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("dirX", dir.x);
		GetComponent<Animator>().SetFloat("dirY", dir.y);

	}

	bool valid(Vector2 dir) {
		// Cast Line from 'next to hero' to 'hero' to ensure the hero can move in the direction 
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}
}



