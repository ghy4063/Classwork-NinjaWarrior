using UnityEngine;
using System.Collections;

public class CollectableObject : MonoBehaviour 
{
	void Start () 
	{
		this.gameObject.GetComponent<Collider>().isTrigger = true;//Make sure the box collider we are using is a trigger so we get OnTrigger messages
	}
	
	/// <summary>
	/// Raises the trigger enter event, this happens when colliders hit & one of them was a trigger
	/// </summary>
	/// <param name='objectHit'>
	/// Object hit.
	/// </param>
	public void OnTriggerEnter(Collider objectHit)
	{
		if(objectHit.CompareTag("Player"))//If we hit the player object, move it to spawn	
		{
			this.AddToCollectablesCount();
			this.KillMe();
		}
	}

	public void AddToCollectablesCount()
	{
		CollectableObjectMaster.instance.CollectablesCount++;
	}
	
	public void KillMe()
	{
		Destroy(this.gameObject);
	}

}
