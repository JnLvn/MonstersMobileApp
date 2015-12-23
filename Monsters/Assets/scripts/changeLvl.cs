using UnityEngine;
using System.Collections;

public class changeLvl : MonoBehaviour {
	
	public void changeScene (string lvlToChangeTo) {
		Application.LoadLevel (lvlToChangeTo);
	}

	public void quitGame(){
		Application.Quit();
	}
}
