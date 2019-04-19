using UnityEngine;
using System.Collections;

/// <summary>
/// This 'kill's the player and moves them to the designated Spawnpoint or Origin(0,0,0)
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class Killbox : MonoBehaviour 
{
	public Transform spawnPoint;
	
	private void Start()
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
			this.MoveToSpawn(objectHit.gameObject);
	}
	
	//Move the passed in object to spawn
	private void MoveToSpawn(GameObject objectToMove)
	{
		objectToMove.transform.position = this.GetSpawnPosition();
	}
	
	/// <summary>
	/// Gets the spawn position.
	/// </summary>
	/// <returns>
	/// The spawn position.
	/// </returns>
	private Vector3 GetSpawnPosition()
	{
		if(this.spawnPoint != null)
			return this.spawnPoint.position;
		else
			return Vector3.zero;
	}
}
