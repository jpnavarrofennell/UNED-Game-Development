using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban
{
    public class SKMovingBoxLight : SKBoxLight
    {
        public bool automove;
        public float waitTime = 0.3f;

        protected bool active;
        protected Vector3 moveVector;

        // Use this for initialization
        void Start()
        {
            active = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        new public bool MoveBox(Vector3 direction, float stepDistance)
        {
            active = true;
            StartCoroutine(AutoMove(direction, stepDistance));
            return false;
        }

        private IEnumerator AutoMove(Vector3 direction, float stepDistance) {
            yield return new WaitForSeconds(waitTime);

            while (active) {
                active = base.MoveBox(direction, stepDistance);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}