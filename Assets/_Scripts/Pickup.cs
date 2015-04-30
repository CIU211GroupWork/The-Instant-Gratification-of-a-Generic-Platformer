using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject goFull;
	private AudioManager audioManager;
	private GameManager gameManager;
	private bool bIsPickedUp;

	// Use this for initialization
	void Start () {
		audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(!bIsPickedUp){
			audioManager.PlayNextClip();
			gameManager.ChangeLevel();
			goFull.SetActive(false);
			bIsPickedUp = true;
		}
	}
}
