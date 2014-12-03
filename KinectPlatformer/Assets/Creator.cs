using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour {


	public GameObject prefab = null;

	public void Create () {
		int previousFail = 0;
		//camera visibility
		Camera cam = Camera.main;
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

		GameObject[] listChara = GameObject.FindGameObjectsWithTag ("character");
			//GameObject.FindObjectsOfType(typeof(CharacterScript));

		//character selection
		if (listChara.Length > 0) {
			int characterType = Random.Range (0, listChara.Length - 1);
			prefab = listChara [characterType];
		}

		//random position and creation of the object
		Vector3 position = new Vector3(Random.Range(-5.0F, 5.0F), 0, Random.Range(-5.0F, 5.0F));
		GameObject newOne = Instantiate(prefab, position, Quaternion.identity) as GameObject;
		int maxTry = 5;
		// while object is visible destroy and crecreate it elsewhere ( timeout 12 try)
		while (GeometryUtility.TestPlanesAABB (planes, newOne.collider.bounds) && (previousFail < maxTry )) {
			print ("in the view !");
			Destroy (newOne);
			previousFail ++;
			if(previousFail < maxTry ){
				print("new try ");
				newOne = Instantiate(prefab, position, Quaternion.identity) as GameObject;
				position = new Vector3(Random.Range(-10.0F, 5.0F), 0, Random.Range(-10.0F, 5.0F));
			}
		} 

		if (! GeometryUtility.TestPlanesAABB (planes, newOne.collider.bounds)){
			print ("out the view !");
		}
	}
}