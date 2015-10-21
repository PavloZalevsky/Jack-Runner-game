using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().freezeRotation = true;// 
    }
	
	// Update is called once per frame
	void Update () {
    }

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "road" || col.gameObject.name == "road1") {

			transform.parent = col.gameObject.transform;
		}	
	}
}
