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
    public class SKTarget : SKTargetLight
    {
        protected bool _ready;

        // Método que se ejecuta únicamente en el primer momento que aparece en pantalla el objeto
        new void Start()
        {
            // Se obtiene la referencia del renderizador del cubo (lo que hace que se vea en pantalla)
            targetRenderer = this.gameObject.GetComponent<Renderer>();

            // Activamos el color en estado desactivado
            targetRenderer.material.color = deactivatedColor;

            // El estado de este objeto es desactivado
            // _status = false;

            // Configuramos este objeto en la escena.
            this.gameObject.transform.parent.name = "Ground";
            this.gameObject.name = "Target";
            this.gameObject.transform.parent = null;

            // Registramos en el singleton este objeto, desde SKGamContro se
            // monitorean todos los objetos SKTarget para ver si el juego ha sido ganado
            SKGameControl.instance.RegisterTarget(this);

            _ready = false;

            if (_status)
            {
                targetRenderer.material.color = activatedColor;
                _ready = true;
            }
        }
    }
}