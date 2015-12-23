using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class doNotDestroy : MonoBehaviour {

	public Toggle toggle;
	public AudioSource audioS;
	
	void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}
	
	void Update() {
		if (!audioS.isPlaying) {
			audioS.Play();
		}
		if (toggle.isOn) {
			audioS.mute = false;
		} else if (!toggle.isOn) {
			audioS.mute = true;
		}
	}
}
