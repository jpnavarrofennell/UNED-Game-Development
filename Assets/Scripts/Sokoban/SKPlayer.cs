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
        private bool _isReadyToMove;

        void Start()
        {
            _isReadyToMove = true;
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Player";
            this.gameObject.transform.parent = null;
            _smoothFollow = Camera.main.GetComponent<SKSmoothFollow>();
            _smoothFollow.target = this.gameObject.transform;
        }

        void Update()
        { 
            if(Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                MoveChar(Vector3.right);
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                MoveChar(Vector3.left);
            }

            if(Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                MoveChar(Vector3.back);
            }

            if(Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                MoveChar(Vector3.forward);
            }
        }

        public void MoveChar(Vector3 direction)
        {
            if(!DetectObstruction() && _isReadyToMove) 
            {
                StartCoroutine(TimedMove(direction));
            }
        }

        private IEnumerator TimedMove(Vector3 direction) 
        {
            _isReadyToMove = false;
            this.transform.Translate(direction);
            yield return new WaitForSeconds(0.1f);
            _isReadyToMove = true;
        }

        private bool DetectObstruction() 
        {
            
            return false;
        }
    }
}