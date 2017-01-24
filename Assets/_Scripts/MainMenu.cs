using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string MainScene;
	public AudioClip uiSound;

	public void Play() {
		AudioSource.PlayClipAtPoint(uiSound, new Vector3(0f,0f,0f));
        SceneManager.LoadScene(1);
	}

	public void Quit() {
		Application.Quit();
	}
}

