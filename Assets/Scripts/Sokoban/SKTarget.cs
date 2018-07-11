using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban 
{
    public class SKTarget : MonoBehaviour
    {
        private bool _status;

        void Awake()
        {
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Target";
            this.gameObject.transform.parent = null;
            SKGameControl.instance.RegisterTarget(this);
        }

        public bool GetStatus() 
        {
            return _status;
        }
    }
}