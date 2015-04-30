using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] acPickupClips;
	public AudioSource BGMSource;
	public AudioSource HeartbeatSource;

	public float fPickupVolume = 0.2f;
	public float fMainMusicVolume = 1.0f;
	public float fHeartbeatVolume = 0.0f;

	private int iClipTracker = 0;

	// Use this for initialization
	void Start () {
		BGMSource.volume = 1.0f;
		HeartbeatSource.volume = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayNextClip() {
		if(iClipTracker >= acPickupClips.Length) {
			AudioSource.PlayClipAtPoint(acPickupClips[acPickupClips.Length-1], transform.position, fPickupVolume);
		}
		else {
			fPickupVolume += 1f;
			AudioSource.PlayClipAtPoint(acPickupClips[iClipTracker], transform.position, fPickupVolume);
			iClipTracker++;

		}
		if(fMainMusicVolume >=0.1) {
			fMainMusicVolume -= 0.2f;
			BGMSource.volume = fMainMusicVolume;
		}
		if(fHeartbeatVolume <= 1) {
			fHeartbeatVolume += 0.2f;
			HeartbeatSource.volume = fHeartbeatVolume;
		}
	}
}
