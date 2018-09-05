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
    public class SKBox : SKBoxLight
    {
        private SKLevel _level;

        void Start()
        {
            // Se obtiene la referencia a SKLevel, que administra el nivel actual
            _level = SKGameControl.instance.levelmanager;
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Box";
            this.gameObject.transform.parent = null;
        }

        new public bool MoveBox(Vector3 direction, float stepDistance)
        {
            if (!_level.GameDone())
            {
                return base.MoveBox(direction, stepDistance);
            }
            else
            {
                return false;
            }
        }

        public void SetLevelController(SKLevel level)
        {
            _level = level;
        }
    }
}