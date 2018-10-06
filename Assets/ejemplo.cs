using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejemplo : MonoBehaviour {
    public GameObject botonGenerico;

	// Use this for initialization
	void Start () {
        GameObject temp = Instantiate(botonGenerico);
        temp.SendMessage("setTexto", "Hola");


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
