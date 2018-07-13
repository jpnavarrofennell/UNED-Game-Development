// Programa Desarrollo de Videojuegos
// Fecha: 10/07/2018
// Autor: Juan Pablo Navarro Fennell
// Clase: SKBox
// Descripción:
// Escuela de Ciencias Exactas y Naturales, UNED 2018.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban 
{
    public class SKBox : MonoBehaviour
    {

        private RaycastHit _hit;
        // Use this for initialization
        void Start()
        {
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Box";
            this.gameObject.transform.parent = null;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool MoveBox(Vector3 direction, float stepDistance)
        {
            if (DetectObstruction(direction, stepDistance))
            {
                return false;
            }
            else
            {
                this.gameObject.transform.Translate(direction);
                return true;
            }
        }

        private bool DetectObstruction(Vector3 direction, float stepDistance)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out _hit, stepDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(direction) * stepDistance, Color.yellow);
                Debug.Log("Collision (Box)");
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(direction) * stepDistance, Color.white);
                return false;
            }
        }
    }

}