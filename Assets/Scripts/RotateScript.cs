using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	public float speed;

	void Update () {
		transform.Rotate (new Vector3(0f,0f,-3f* speed));
	}
}
