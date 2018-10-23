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

        public int currentBlock
        {
            get
            {
                return _currentBlock;
            }
            set
            {
                _currentBlock = value;
            }
        }

        private int _characterMoves;
        private float _activePlayTime;
        private List<SKTarget> targets;
        private SKLevel _level;
        private int _currentBlock;

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
            _level = null;
            ResetTargets();
            SceneManager.LoadScene(value);
        }

        public void RestartGame()
        {
            _level = null;
            ResetTargets();
            _characterMoves = 0;
            _activePlayTime = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ResetCurrentLevel()
        {
            _level = null;
            ResetTargets();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
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

        public void AddMove() 
        {
            _characterMoves++;
        }

        public void AddPlayTime(float value) 
        {
            _activePlayTime += value;
        }

        public void OnApplicationQuit()
        {
            
        }
    }
}

