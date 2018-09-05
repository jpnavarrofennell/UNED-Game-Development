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
    public class SKPlayerLight : MonoBehaviour
    {
        // Declaración de miembros de clase públicas
        public float stepDistance = 1f;
        public Transform playerVisual;

        // Declaración de miembros de clase privadas
        protected Vector3 _direction;
        protected bool _isReadyToMove;
        protected RaycastHit _hit;
        protected SKBoxLight _box;

        // Método que se ejecuta únicamente en el primer momento que aparece en pantalla el objeto
        void Start()
        {
            _isReadyToMove = true;
        }

        // Método que se ejecuta en cada refrescamiento de pantalla
        public virtual void Update()
        {
            // Lectura de teclado 
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveChar(Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveChar(Vector3.left);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveChar(Vector3.back);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveChar(Vector3.forward);
            }
        }

       
        public virtual void UIControl(int value)
        {
            // Lectura de teclado 
            if (value == 0)
            {
                MoveChar(Vector3.right);
            }

            if (value == 1)
            {
                MoveChar(Vector3.left);
            }

            if (value == 2)
            {
                MoveChar(Vector3.back);
            }

            if (value == 3)
            {
                MoveChar(Vector3.forward);
            }
        }

        // Método privado encargado de mover el personaje
        public virtual void MoveChar(Vector3 direction)
        {
            // Verificación de colisiones
            if(!DetectObstruction(direction) && _isReadyToMove) 
            {
                // Se ejecuta la corutina 
                StartCoroutine(TimedMove(direction));
            }
        }

        // Método corutina
        public virtual IEnumerator TimedMove(Vector3 direction) 
        {
            _isReadyToMove = false;
            this.transform.Translate(direction);

            // Rotar el personaje
            if (direction == Vector3.left)
            {
                playerVisual.eulerAngles = new Vector3(0f,0f,0f);
            }
            if (direction == Vector3.forward)
            {
                playerVisual.eulerAngles = new Vector3(0f, 90f, 0f);
            }
            if (direction == Vector3.right)
            {
                playerVisual.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            if (direction == Vector3.back)
            {
                playerVisual.eulerAngles = new Vector3(0f, 270f, 0f);
            }

            yield return new WaitForSeconds(0.1f);
            _isReadyToMove = true;
        }

        // Método que verifica si existen coliciones
        public virtual bool DetectObstruction(Vector3 direction) 
        {
            // Se lanza un rayo desde la posición del persona con dirección que indico el jugador
            // En caso de existir colisión, se guardan sus datos en la propiedad de la clase llamada _hit
            if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out _hit, stepDistance))
            {
                // Se dibuja en el editor de Unity un rayo
                Debug.DrawRay(transform.position, transform.TransformDirection(direction) * stepDistance, Color.yellow);

                // Colisión con una caja, se consulta mediante la información almacenada en _hit
                if(_hit.collider.gameObject.tag.Equals("Box")) 
                {
                    // Obtengo la referencia a la clase SKBox para consultar el obejto que intento mover
                    _box = _hit.collider.gameObject.GetComponent<SKBoxLight>();

                    // Evaluar si se puedo mover la caja
                    // Invocar metodos de mover la caja
                    if(_box.MoveBox(direction, stepDistance)) 
                    {
                        // La caja que mueve el usuario pudo moverse, 
                        // por tanto, no hay obstrucción
                        return false;
                    }
                    else 
                    {
                        // La caja no se pudo mover, 
                        // por tanto, si hay obstrucción
                        return true;
                    }
                }

                // En caso de ser una colisión simple, se devuelve un valor afirmativo de colisión,
                // posiblemente con una pared
                return true;
            }
            else
            {
                // En caso de no haber nada se devuelve una valor falso, es decir, no hubo colisición.
                Debug.DrawRay(transform.position, transform.TransformDirection(direction) * stepDistance, Color.white);
                return false;
            }
        }
    }
}