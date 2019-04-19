using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps track of your Collectables count & displays the count on the screen
/// </summary>
public class CollectableObjectMaster : MonoBehaviour 
{
	#region Singleton
	//This is a singleton, it makes sure we always have a CollectableObjectMaster.
    private static CollectableObjectMaster collectableObjectMasterInstance = null;

    public static CollectableObjectMaster instance
    {
        get
        {
            if (collectableObjectMasterInstance == null)
            {
                collectableObjectMasterInstance = FindObjectOfType(typeof(CollectableObjectMaster)) as CollectableObjectMaster;
            }

            if (collectableObjectMasterInstance == null)//If we didn't find a CollectableObjectMaster, make one
            {
                GameObject newObj = new GameObject("CollectableObjectMaster");
                collectableObjectMasterInstance = newObj.AddComponent(typeof(CollectableObjectMaster)) as CollectableObjectMaster;
                Debug.Log("Could not find CollectableObjectMaster, so I made one");
            }

            return collectableObjectMasterInstance;
        }
    }
	#endregion
	
	#region Members
	[UnityEngine.SerializeField]//This allows us to inspect private members in the inspector
	private int collectablesCount;//How many collectables we have
	
	public GUIStyle collectableCountDisplayStyle;
	
	public string nameOfCollectable = "Collectable";
	#endregion
	
	#region Properties	
	public int CollectablesCount
	{
		get { return this.collectablesCount;}
		set { this.collectablesCount = value;}
	}
	#endregion
	
	
	#region Methods
	public void OnGUI()
	{		
		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		{
			GUILayout.BeginVertical();
				GUILayout.Space(10f);//A little buffer room ;)
				GUILayout.BeginHorizontal();
				{
					GUILayout.FlexibleSpace();
						this.DrawCollectableCount();
					GUILayout.FlexibleSpace();
				}
				GUILayout.EndHorizontal();
				GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}
	
	private void DrawCollectableCount()
	{
		if(this.collectableCountDisplayStyle == null)
			GUILayout.Label(this.GetCollectableString());
		else
			GUILayout.Label(this.GetCollectableString(), this.collectableCountDisplayStyle);
	}
	
	private string GetCollectableString()
	{
		return (this.CollectablesCount.ToString() + " " + this.nameOfCollectable);
	}
	#endregion
}
