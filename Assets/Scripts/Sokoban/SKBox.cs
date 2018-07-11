using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.transform.parent.name = "Ground";
        this.gameObject.name = "Box";
        this.gameObject.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
