using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnedSokoban;

public class SKFlowchartHelper : MonoBehaviour {

    public Flowchart flchart;

	// Use this for initialization
	void Start () {
        flchart.SetIntegerVariable("movimientos", SKGameControl.instance.characterMoves);
        flchart.SetIntegerVariable("bloqueactual", SKGameControl.instance.currentBlock);

        SKGameControl.instance.characterMoves = 0;

        flchart.ExecuteBlock("Main");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
