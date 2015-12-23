using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class heroStuff : MonoBehaviour {

	public GameObject player;
	public Text livesTxt;
	int lives;
	bool gameOver = false;
	public Text gameoverText;


	// Use this for initialization
	void Start () {
		lives = 1;
		livesTxt.text = ("Lives:" + lives);
		gameoverText.text = "";
	}

	void OnTriggerEnter2D(Collider2D co) {
		// If enemies pass through player destroy player and display gameover
		if (co.name == "enemy" || co.name == "enemy2" || co.name == "enemy3" || co.name == "enemy4") {
			lives--;
			livesTxt.text = ("Lives:" + lives.ToString());
			Destroy (player);
			GameOver();
		}
	}

	public void GameOver ()
	{
		gameoverText.text = "Game Over!!!!!!!";
		gameOver = true;
	}
}
