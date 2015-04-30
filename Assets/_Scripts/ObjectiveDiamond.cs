using UnityEngine;
using System.Collections;

public class ObjectiveDiamond : MonoBehaviour {

	public GameObject ActiveDiamond;


	// Use this for initialization
	void Start () {
		ActiveDiamond.SetActive(false);
	}

	public void ActivateDiamond() {
		ActiveDiamond.SetActive(true);
	}
}
