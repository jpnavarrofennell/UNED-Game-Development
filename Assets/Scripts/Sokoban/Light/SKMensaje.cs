using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban
{
    public class SKMensaje : MonoBehaviour
    {
        public GameObject mensaje;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Hola");
                mensaje.SetActive(true);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                mensaje.SetActive(false);
            }
        }
    }
}