using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour {

	public GameObject head;
	private GameObject prefab = null;
	private int numberCreated = 0;
	private GameObject[] listChara;
	private bool isFirstCall =true;
	public void majCharact(){
		listChara = GameObject.FindGameObjectsWithTag ("character");
		print ("maj list character : " + listChara.Length);
	}


	public void Create () {
		numberCreated++;
		if (isFirstCall) {
			majCharact();
			isFirstCall =false;
		}
		print ("create one more, total :" + numberCreated);
			//camera visibility
			Camera cam = Camera.main;
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes (cam);

			//GameObject.FindObjectsOfType(typeof(CharacterScript));

			//character selection
			if (listChara.Length > 1) {
					int characterType = Random.Range (0, listChara.Length - 1);
					prefab = listChara [characterType];
			}

			float range = 3.0F;
			//random position and creation of the object
			Vector3 position = new Vector3 (Random.Range (head.transform.position.x - range, head.transform.position.x + range), 0, Random.Range (head.transform.position.z - range, head.transform.position.z + range));
			GameObject newOne = Instantiate (prefab, position, Quaternion.identity) as GameObject;
			// while object is visible destroy and crecreate it elsewhere ( timeout 12 try)
			if (GeometryUtility.TestPlanesAABB (planes, newOne.collider.bounds)) {
					print ("in the view !");
					Destroy (newOne);
			}
			else {
				print ("out the view !");
				newOne.transform.LookAt(head.transform.position);
			}
	}
}