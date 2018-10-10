// Programa Desarrollo de Videojuegos
// Fecha: 10/07/2018
// Autor: Juan Pablo Navarro Fennell
// Clase: SKPlayer
// Descripción:
// Escuela de Ciencias Exactas y Naturales, UNED 2018.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban 
{
    public class SKPlayer : SKPlayerLight
    {
        // Declaración de miembros de clase públicas
        //public float threshold;

        // Declaración de miembros de clase privadas
        private SKLevel _level;
        private SKSmoothFollow _smoothFollow;

        // Método que se ejecuta únicamente en el primer momento que aparece en pantalla el objeto
        void Start()
        {
            // Se obtiene la referencia a SKLevel, que administra el nivel actual
            _level = SKGameControl.instance.levelmanager;
            _isReadyToMove = true;
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Player";
            this.gameObject.transform.parent = null;
            _smoothFollow = Camera.main.GetComponent<SKSmoothFollow>();
            _smoothFollow.target = this.gameObject.transform;
        }

        // Método que se ejecuta en cada refrescamiento de pantalla
        public override void Update()
        {
            if(_level.GameStarted() && !_level.GameDone()) 
            {
                base.Update();
            }
        }

        public void SetLevelController(SKLevel level) 
        {
            _level = level;
        }

        // Método privado encargado de mover el personaje
        public override void MoveChar(Vector3 direction)
        {
            base.RotateChar(direction);
            // Verificación de colisiones
            if(!DetectObstruction(direction) && _isReadyToMove) 
            {
                // Se ejecuta la corutina 
                StartCoroutine(TimedMove(direction));
                if(SKGameControl.instance != null) 
                {
                    SKGameControl.instance.AddMove();
                }
            }
        }
    }
}