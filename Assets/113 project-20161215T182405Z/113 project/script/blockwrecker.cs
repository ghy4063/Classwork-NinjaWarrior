using UnityEngine;
using System.Collections;

public class blockwrecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void OnTriggerEnter(Collider objectHit)
	{
		if(objectHit.CompareTag("Player")){
			Destroy(GameObject.FindWithTag("blocker"));
				}
}
}