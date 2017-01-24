using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] acPickupClips;
	public AudioSource BGMSource;
	public AudioSource HeartbeatSource;

	public float fPickupVolume = 0.2f;
	public float fHeartbeatVolume = 0.1f;

	private float lerpToVol;
	private bool volLerp = false;
	private int iClipTracker = 0;
	private AudioClip acRandomClip;
	private AudioClip acPrevRandomClip;

	// Use this for initialization
	void Start () {
		HeartbeatSource.volume = fHeartbeatVolume;

		acRandomClip = new AudioClip();
		acPrevRandomClip = new AudioClip();
	}
	
	// Update is called once per frame
	void Update () {
		if(volLerp) {

			fHeartbeatVolume += Time.deltaTime * 0.1f;

			HeartbeatSource.volume = fHeartbeatVolume;

			if(fHeartbeatVolume >= lerpToVol) {
				fHeartbeatVolume = lerpToVol;
				volLerp = false;
			}
		}
	}

	public void PlayNextClip() {
		if(iClipTracker >= acPickupClips.Length) {
            BGMSource.PlayOneShot(acPickupClips[acPickupClips.Length - 1], fPickupVolume);
		}
		else {
            fPickupVolume += 0.75f;
            BGMSource.PlayOneShot(acPickupClips[iClipTracker], fPickupVolume);
			iClipTracker++;
		}
		lerpToVol = fHeartbeatVolume + 0.75f;
		volLerp = true;
	}

	public void PlayRandomClip() {
		bool bClipPlayed = false;

		while(!bClipPlayed) {
			acRandomClip = acPickupClips[Random.Range(0, acPickupClips.Length)];
			if(acRandomClip !=acPrevRandomClip) {
				AudioSource.PlayClipAtPoint(acRandomClip, this.transform.position, Random.Range(0.2f, 0.81f));
				acPrevRandomClip = acRandomClip;
				bClipPlayed = true;
			}

		}
	}

}
