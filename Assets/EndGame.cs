using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public float fPlaybackRate;

	private float fPlaybackCounter;
	private AudioManager audioManager;
	void Start() {
		audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
		fPlaybackCounter = fPlaybackRate;
	}

	// Update is called once per frame
	void Update () {
		if(fPlaybackCounter > 0.0f) {
			fPlaybackCounter -= Time.deltaTime;
		}
		if(fPlaybackCounter <= 0.0f) {
			audioManager.PlayRandomClip();
			fPlaybackCounter = fPlaybackRate;
		}
	}
}
