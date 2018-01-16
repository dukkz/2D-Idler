using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDraw : MonoBehaviour {

	public float xSize, ySize;

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, new Vector3(xSize, ySize));
	}
}
