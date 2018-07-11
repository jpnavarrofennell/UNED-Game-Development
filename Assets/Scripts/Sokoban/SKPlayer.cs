using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban 
{
    public class SKPlayer : MonoBehaviour
    {
        public float threshold;
        private SKSmoothFollow _smoothFollow;
        private Vector3 _direction;

        void Start()
        {
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Player";
            this.gameObject.transform.parent = null;
            _smoothFollow = Camera.main.GetComponent<SKSmoothFollow>();
            _smoothFollow.target = this.gameObject.transform;
        }

        // Update is called once per frame
        void Update()
        {
            _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            MoveChar(_direction);
        }

        public void MoveChar(Vector3 direction)
        {
            if(DetectObstruction()) 
            {
                
            }
        }

        private bool DetectObstruction() 
        {
            return false;
        }
    }
}