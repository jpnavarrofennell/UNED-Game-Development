// Programa Desarrollo de Videojuegos
// Fecha: 10/07/2018
// Autor: Juan Pablo Navarro Fennell
// Clase: SKTarget
// Descripción:
// Escuela de Ciencias Exactas y Naturales, UNED 2018.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban 
{
    public class SKTarget : MonoBehaviour
    {
        public Color activatedColor = Color.green;
        public Color deactivatedColor = Color.yellow;

        private bool _status;
        private Renderer targetRenderer;

        // Método que se ejecuta únicamente en el primer momento que aparece en pantalla el objeto
        void Start()
        {
            // Se obtiene la referencia del renderizador del cubo (lo que hace que se vea en pantalla)
            targetRenderer = this.gameObject.GetComponent<Renderer>();

            // Activamos el color en estado desactivado
            targetRenderer.material.color = deactivatedColor;

            // El estado de este objeto es desactivado
            _status = false;

            // Configuramos este objeto en la escena.
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Target";
            this.gameObject.transform.parent = null;

            // Registramos en el singleton este objeto, desde SKGamContro se
            // monitorean todos los objetos SKTarget para ver si el juego ha sido ganado
            SKGameControl.instance.RegisterTarget(this);
        }

        // Método de la clase que permite consultar el estado de esta plataforma
        public bool GetStatus() 
        {
            return _status;
        }

        // Método que se invoca cada vez que se dispara el evento de colisiones entrantes
        private void OnTriggerEnter(Collider other)
        {
            // Se consulta si la colisión entrante se dio con un objeto con al etiqueta "Box"
            if(other.gameObject.tag.Equals("Box")) 
            {
                // Activamos el color en estado activado
                targetRenderer.material.color = activatedColor;

                // Se pone en positivo el estado de este objetivo
                _status = true;
            }
        }

        // Método que se invoca cada vez que se dispara el evento de colisiones salientes
        private void OnTriggerExit(Collider other)
        {
            // Se consulta si la colisión saliente se dio con un objeto con al etiqueta "Box"
            if (other.gameObject.tag.Equals("Box"))
            {
                // Activamos el color en estado desactivado
                targetRenderer.material.color = deactivatedColor;

                // Se pone en negativo el estado de este objetivo
                _status = false;
            }
        }
    }
}