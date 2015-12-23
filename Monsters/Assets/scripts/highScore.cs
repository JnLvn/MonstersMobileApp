using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highScore : MonoBehaviour {

	public Text hs;
	private int score;
	
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("Score");
		hs.text = "" + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
