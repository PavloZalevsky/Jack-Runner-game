using UnityEngine;
using System.Collections;

public class DieBoxScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "Box" )
        {
            col.gameObject.SetActive(false);
        }	
	}
}
