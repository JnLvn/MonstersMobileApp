using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class food : MonoBehaviour {

	public Text scoreTxt;
	
	static int score;
	private int hs;

	void start(){
		score = 0;
		hs = PlayerPrefs.GetInt ("Score", 0);
	}

	// Waits for a object to trigger it
	void OnTriggerEnter2D(Collider2D co){
		// Implement score here to add to total
		if (co.name == "hero") {
			Destroy (gameObject);
			score++;
			scoreTxt.text = ("Score: " + score.ToString());
			// Store highscore in player prefs
			if (score > hs) {
				PlayerPrefs.SetInt("Score", score);
				PlayerPrefs.Save();
			}
		}
	}


}
