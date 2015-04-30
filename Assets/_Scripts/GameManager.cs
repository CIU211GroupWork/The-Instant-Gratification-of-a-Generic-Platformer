using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int iLevel;
	public float fChangeLevelTime;
	public GameObject[] Levels;
	public ObjectiveDiamond[] ObjectiveDiamonds;

	private bool bChangingLevel;
	private bool bFadingIn = true;
	private bool bFadingOut;
	private float fLevelChangeCountdown;
	private GameObject goCurrentLevel;
	private Object cloneLevel;

	// Use this for initialization
	void Start () {
		goCurrentLevel = Levels[0];
		cloneLevel = Instantiate(goCurrentLevel, new Vector3 (0,0,0), Quaternion.identity);
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);


	}
	
	// Update is called once per frame
	void Update () {
		if(bFadingIn) {
			StartScene();
		}
		if(bChangingLevel){
			if(iLevel <= ObjectiveDiamonds.Length) {
				ObjectiveDiamonds[iLevel].ActivateDiamond();
			}

			if(fLevelChangeCountdown > 0) {
				EndScene();
				fLevelChangeCountdown -= Time.deltaTime;
			}

			if(fLevelChangeCountdown <= 0) {
				bFadingIn = true;
				Destroy(cloneLevel);
				iLevel++;
				goCurrentLevel = Levels[iLevel];
				cloneLevel = Instantiate(goCurrentLevel, new Vector3 (0,0,0), Quaternion.identity);
				Debug.Log("Cloned Level");
				fLevelChangeCountdown = fChangeLevelTime;
				bChangingLevel = false;
			}
		}
	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fChangeLevelTime * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fChangeLevelTime * Time.deltaTime);
	}


	void StartScene ()
	{
		bFadingIn = true;
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;

			bFadingIn = false;
		}
	}
	
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
//		if(guiTexture.color.a >= 0.95f)
//			// ... reload the level.
//			Application.LoadLevel(0);
	}
	public void ChangeLevel() {
		fLevelChangeCountdown = fChangeLevelTime;
		bChangingLevel = true;
	}
}
