using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour {

	public Toggle pause;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (pause.isOn) {
			Time.timeScale = 1;
		} else if (!pause.isOn) {
			Time.timeScale = 0;
		}
	}
}
