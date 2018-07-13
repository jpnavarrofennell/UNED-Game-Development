// Programa Desarrollo de Videojuegos
// Fecha: 10/07/2018
// Autor: Juan Pablo Navarro Fennell
// Clase: SKUtilities
// Descripción:
// Escuela de Ciencias Exactas y Naturales, UNED 2018.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnedSokoban {
    public class SKGameControl : MonoBehaviour
    {
        public static SKGameControl instance;

        public int characterMoves 
        {
            get 
            { 
                return _characterMoves;  
            }
            set 
            { 
                _characterMoves = value;  
            }
        }

        public float activePlayTime 
        {
            get 
            { 
                return _activePlayTime; 
            }
            set 
            { 
                _activePlayTime = value; 
            }
        }

        public SKLevel levelmanager 
        {
            get 
            {
                return _level;
            }
            set 
            {
                _level = value;
            }
        }

        private int _characterMoves;
        private float _activePlayTime;
        private List<SKTarget> targets;
        private SKLevel _level;

        // Use this for initialization
        void Awake()
        {
            if(SKGameControl.instance == null) 
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
                targets = new List<SKTarget>();
            }
            else 
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(string value) 
        {
            SceneManager.LoadScene(value);
        }

        public void RestartGame() 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void RegisterTarget(SKTarget newTarget) 
        {
            targets.Add(newTarget);
        }

        public void ResetTargets() 
        {
            targets.Clear();
        }

        public SKTarget[] GetTargets()
        {
            return targets.ToArray();
        }

        public void OnApplicationQuit()
        {
            
        }
    }
}

