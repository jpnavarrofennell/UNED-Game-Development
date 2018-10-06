using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban 
{
    public class SKSwitchLight : SKTargetLight
    {
        public bool once = true;
        public GameObject[] switchObjects;

        protected bool actualState;

        // Use this for initialization
        new void Start()
        {
            base.Start();
            actualState = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        new void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            targetRenderer.material.color = (_status) ? activatedColor : deactivatedColor;
            SwitchObjects(actualState);
        }

        new void OnTriggerExit(Collider other) 
        {

        }

        protected void SwitchObjects(bool value) 
        {
            foreach(GameObject switchObject in switchObjects) 
            {
                switchObject.SetActive(value);
            }
        }

        public void AddSwitchableObject(GameObject value) 
        {
            if(switchObjects.Length == 0) {
                switchObjects = new GameObject[1];
                switchObjects[0] = value;
            }
            else 
            {
                GameObject[] temp = switchObjects;
                switchObjects = new GameObject[switchObjects.Length + 1];
                for (int i = 0; i < temp.Length; i++) 
                {
                    switchObjects[i] = temp[i];
                }
            }
        }
    }
}