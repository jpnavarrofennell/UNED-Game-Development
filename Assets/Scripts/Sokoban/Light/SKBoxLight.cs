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
    public class SKBoxLight : MonoBehaviour
    {
        void Start()
        {
            
        }

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
            RaycastHit _hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out _hit, stepDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(direction) * stepDistance, Color.yellow);
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