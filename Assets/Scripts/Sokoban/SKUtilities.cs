// Programa Desarrollo de Videojuegos
// Fecha: 10/07/2018
// Autor: Juan Pablo Navarro Fennell
// Clase: SKUtilities
// Descripción:
// Escuela de Ciencias Exactas y Naturales, UNED 2018.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnedSokoban
{
    public class SKUtilities : MonoBehaviour
    {
        // Miembros de clase públicos
        public GameObject PanelCreditos;
        public GameObject PanelPausa;
        public Text MovesCounter;
        public Text TimeCounter;

        private void Update()
        {
            if (MovesCounter != null && TimeCounter != null) 
            {
                MovesCounter.text = SKGameControl.instance.characterMoves.ToString();
                TimeCounter.text = Mathf.RoundToInt(SKGameControl.instance.activePlayTime).ToString();
            }
        }

        public void QuitSokoban()
        {
            Application.Quit();
        }

        public void NextScene(string sceneName)
        {
            if(SKGameControl.instance != null) 
            {
                SKGameControl.instance.LoadScene(sceneName);
            }
            else 
            {
                Debug.LogError("SKGameControl without instance");
            }
        }

        public void PausarTiempo() 
        {
            Time.timeScale = 0f;
        }

        public void ReanudarTiempo() 
        {
            Time.timeScale = 1f;
        }

        public void MostrarCreditos() 
        {
            if (PanelCreditos != null)
                PanelCreditos.SetActive(true);
            else
                Debug.LogError("Verificar si el panel de créditos se encuntra en la escena");
        }

        public void OcultarCreditos() 
        {
            if (PanelCreditos != null) 
                PanelCreditos.SetActive(false);
            else
                Debug.LogError("Verificar si el panel de créditos se encuntra en la escena");
        }
    }
}

