using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban 
{
    public class SKCounterObstacleLight : SKBoxLight
    {
        protected int hitsCounter;
        protected Renderer _render;
        protected BoxCollider _collider;
        protected float hitFactor;

        public int hitLimit;
        public Color baseColor;
        public Color midColor;
        public Color terminalColor;
        public Color hitColor;
        public bool deactivateBoxOnCounter = true;

        // Use this for initialization 
        void Start()
        {
            hitsCounter = 0;
            hitFactor = hitLimit / 3;
            _render = GetComponent<Renderer>();
            _collider = GetComponents<BoxCollider>()[0];
            _render.material.color = baseColor;
        }


        public override bool MoveBox(Vector3 direction, float stepDistance)
        {
            if (hitsCounter != hitLimit)
            {
                hitsCounter++;
                StartCoroutine(ColorHits());
                return false;
            }
            else 
            {
                if(deactivateBoxOnCounter) 
                {
                    _render.enabled = false;
                    _collider.enabled = false;
                    return true;
                }
                else 
                {
                    return base.MoveBox(direction, stepDistance);
                }
            }
        }

        private IEnumerator ColorHits() 
        {
            _render.material.color = hitColor;
            yield return new WaitForEndOfFrame();
            _render.material.color = (((hitsCounter / 4) * 2) >= (hitFactor * 2)) ? terminalColor : midColor;

            yield return new WaitForEndOfFrame();

            _render.material.color = hitColor;
            yield return new WaitForEndOfFrame();
            _render.material.color = (((hitsCounter / 4) * 2) >= (hitFactor * 2)) ? terminalColor : midColor;
        }
    }


}

