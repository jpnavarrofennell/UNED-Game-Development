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
    public class SKTargetLight : MonoBehaviour
    {
        public Color activatedColor = Color.green;
        public Color deactivatedColor = Color.yellow;
        public string targetTag = "Box";

        [SerializeField]
        protected bool _status;
        protected Renderer targetRenderer;

        // Método que se ejecuta únicamente en el primer momento que aparece en pantalla el objeto
        protected void Start()
        {
            // Se obtiene la referencia del renderizador del cubo (lo que hace que se vea en pantalla)
            targetRenderer = this.gameObject.GetComponent<Renderer>();

            // Activamos el color en estado desactivado
            targetRenderer.material.color = deactivatedColor;

            // El estado de este objeto es desactivado
            _status = false;
        }

        // Método de la clase que permite consultar el estado de esta plataforma
        public bool GetStatus() 
        {
            return _status;
        }

        // Método que se invoca cada vez que se dispara el evento de colisiones entrantes
        protected void OnTriggerEnter(Collider other)
        {
            // Se consulta si la colisión entrante se dio con un objeto con al etiqueta "Box"
            if(other.gameObject.tag.Equals(targetTag)) 
            {
                // Activamos el color en estado activado
                if(targetRenderer != null) 
                    targetRenderer.material.color = activatedColor;

                // Se pone en positivo el estado de este objetivo
                _status = true;
            }
        }

        // Método que se invoca cada vez que se dispara el evento de colisiones salientes
        protected void OnTriggerExit(Collider other)
        {
            // Se consulta si la colisión saliente se dio con un objeto con al etiqueta "Box"
            if (other.gameObject.tag.Equals(targetTag))
            {
                // Activamos el color en estado desactivado
                targetRenderer.material.color = deactivatedColor;

                // Se pone en negativo el estado de este objetivo
                _status = false;
            }
        }
    }
}