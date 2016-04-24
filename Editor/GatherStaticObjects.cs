using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Media;

/// <summary>
/// Gather and list static objects in the scene. The purpose of this is to check what objects are static,
/// which have a concave mesh collider, and other things that may cause a performance impact.
/// </summary>


public class GatherStaticObjects : Editor 
{

	private static string FILENAME = "Assets/staticObjects.txt";
	private static string STATIC_HEADER = "Static Objects\n";
	private static string NON_STATIC_HEADER = "Non-static Objects\n";
	private static string CONCAVE_HEADER = "Concave Mesh Colliders\n";
	private static string SEPARATOR = "\n\n";

	/// <summary>
	/// Lists all static objects in the scene.
	/// </summary>
	static List<GameObject> ListStaticObjects() 
	{
		return GameObject.FindObjectsOfType<GameObject>().Where(d=> d.isStatic).ToList();
	}

	static List<GameObject> ListNonStaticObjects()
	{
		return GameObject.FindObjectsOfType<GameObject>().Where(d=> d.isStatic == false).ToList();
	}

	/// <summary>
	/// Lists all gameobjects with concave mesh colliders.
	/// </summary>
	static List<MeshCollider> ListConcaveMeshColliders()
	{
		return GameObject.FindObjectsOfType<MeshCollider>().Where(d=> d.convex == false).ToList();
	}

	/// <summary>
	/// Makes the report. Currently writes to a text file.
	/// </summary>
	[MenuItem("Tools/Aceade/Gather Static Objects")]
	public static void MakeReport()
	{
	 	
	 	// get each list
	 	List<GameObject> staticObjects = ListStaticObjects();
	 	List<GameObject> nonStaticObjects = ListNonStaticObjects();
	 	List<MeshCollider> concaveColliders = ListConcaveMeshColliders();

		Debug.Log(string.Format("Gathered lists. {0} static objects, {1} non-static objects, {2} concave colliders", staticObjects.Count, nonStaticObjects.Count, concaveColliders.Count ));

	 	// loop through each list, and write each entry into the file
	 	string staticObjectsString = string.Empty;
	 	string nonStaticObjectsString = string.Empty;
	 	string concaveString = string.Empty;

	 	// gather the static objects into a string
	 	for (int i = 0; i < staticObjects.Count; i++) 
	 	{
	 		staticObjectsString += (staticObjects[i].name + "\n");
	 	}

	 	// gather the non-static objects into a string
		for (int i = 0; i < nonStaticObjects.Count; i++) 
	 	{
	 		nonStaticObjectsString += (nonStaticObjects[i].name + "\n");
	 	}

		for (int i = 0; i < concaveColliders.Count; i++) 
	 	{
	 		concaveString += (concaveColliders[i].name + "\n");
	 	}

	 	// format it into a semi-readable string
	 	string finalString = STATIC_HEADER;
	 	finalString += staticObjectsString;
	 	finalString += SEPARATOR;
	 	finalString += NON_STATIC_HEADER;
	 	finalString += nonStaticObjectsString;
	 	finalString += SEPARATOR;
	 	finalString += CONCAVE_HEADER;
	 	finalString += concaveString;

	 	File.WriteAllText(FILENAME, finalString);
	 	Debug.Log(string.Format("Report generated and stored at {0}", FILENAME));
	}
}
