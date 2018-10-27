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
        public Text PersonalBestCounter;
        public bool isEndGameScreen;
        public bool isMainGameScreen;
        public float screenShakeFactor = 8f;

        private void Start()
        {
            if (isEndGameScreen)
            {
                StartCoroutine(ShowMovesWithScreenShake());
            }
            if (isMainGameScreen) 
            {
                SKGameControl.instance.characterMoves = 0;
                SKGameControl.instance.activePlayTime = 0;
            }
            if( !isEndGameScreen && !isMainGameScreen) 
            {
                StartCoroutine(SetUpScene());
            }
        }

        private IEnumerator SetUpScene() 
        {
            bool ready = false;
            while(!ready) {
                yield return new WaitForEndOfFrame();
                if(SKGameControl.instance.levelmanager != null) 
                {
                    ready = true;
                    PersonalBestCounter.text = PlayerPrefs.GetInt(
                        "Best-" + SKGameControl.instance.levelmanager.levelName, 
                        -1)
                        .ToString();
                }
            }
        }

        private void Update()
        {
            if (MovesCounter != null && TimeCounter != null) 
            {
                MovesCounter.text = SKGameControl.instance.characterMoves.ToString();
                TimeCounter.text = Mathf.RoundToInt(SKGameControl.instance.activePlayTime).ToString();
            }

            if(PanelPausa != null && Input.GetKeyDown(KeyCode.Escape)) 
            {
                RunPause();
            }
        }

        public void RunPause() 
        {
            PausarTiempo();
        }

        public void QuitSokoban()
        {
            Application.Quit();
        }

        public void NextScene(string sceneName)
        {
            ReanudarTiempo();
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
            if (PanelPausa != null)
            {
                PanelPausa.SetActive(true);
            }
            Time.timeScale = 0f;
        }

        public void ReanudarTiempo() 
        {
            if(PanelPausa != null) 
            {
                PanelPausa.SetActive(false);
            }
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

        private IEnumerator ShowMovesWithScreenShake()
        {
            Vector3 tempPos = MovesCounter.transform.position;
            MovesCounter.text = "";

            for (int i = 0; i <= SKGameControl.instance.characterMoves; i++) 
            {
                MovesCounter.text = i.ToString();

                // The Art Of Screenshake hecho simple,
                // como Vlambeer (investigar esto en YouTube).
                MovesCounter.transform.position = new Vector3(
                    MovesCounter.transform.position.x + Random.Range(-screenShakeFactor, screenShakeFactor),
                    MovesCounter.transform.position.y + Random.Range(-screenShakeFactor, screenShakeFactor),
                    MovesCounter.transform.position.z + Random.Range(-screenShakeFactor, screenShakeFactor)
                );
                yield return new WaitForEndOfFrame();
                MovesCounter.transform.position = tempPos;
                // Fin de Screenshake
            }
            MovesCounter.fontSize = (int)(MovesCounter.fontSize * 1.2f);
            yield return new WaitForEndOfFrame();
        }

        public void ResetGame() 
        {
            SKGameControl.instance.ResetCurrentLevel();
        }
    }
}

