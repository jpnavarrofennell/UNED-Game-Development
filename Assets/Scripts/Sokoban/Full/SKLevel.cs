// Programa Desarrollo de Videojuegos
// Fecha: 10/07/2018
// Autor: Juan Pablo Navarro Fennell
// Clase: SKUtilities
// Descripción:
// Escuela de Ciencias Exactas y Naturales, UNED 2018.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace UnedSokoban 
{
    [System.Serializable]
    public class LevelElements
    {
        public string name;
        public GameObject prefab;
        public char key;
    }

    public class SKLevel : MonoBehaviour
    {
        public string levelName;
        public string nextLevelName;
        public LevelElements[] elements;

        private bool _gameStart;
        private bool _gameDone;
        private bool _nextGame;
        private int _curX;
        private int _curY;
        private int _curZ;
        private string _levelload;
        private SKTarget[] _targets;

        private void Start()
        {
            _gameStart = false;
            _gameDone = false;
            StartCoroutine(InitGame());
        }

        private void Update()
        {
            if(!_gameDone) 
            {
                if (_gameStart)
                {
                    GameDone();
                    SKGameControl.instance.AddPlayTime(Time.deltaTime);
                }
            }
        }

        public bool GameDone() 
        {
            _gameDone = true;
            foreach (SKTarget target in _targets)
            {
                if (!target.GetStatus())
                {
                    _gameDone = false;
                }
            }
            if (_gameDone)
            {
                if(!_nextGame) StartCoroutine(NextLevel());
                Debug.Log("Win");
            }
            return _gameDone;
        }

        private IEnumerator NextLevel() 
        {
            _nextGame = true;
            yield return new WaitForSeconds(1f);
            SKGameControl.instance.LoadScene(this.nextLevelName);
        }

        private IEnumerator InitGame()
        {
            _curX = 0;
            _curY = 0;
            _curZ = 0;

            // Se registra SKLevel dentro de SKGameControl para que quede 
            // accesible a otras clases dentro de la escena
            SKGameControl.instance.levelmanager = this;

            // Lectura del archivo
            string path = Application.dataPath + "/StreamingAssets/Sokoban/" + levelName + ".txt";
            StreamReader reader = new StreamReader(path);
            _levelload = reader.ReadToEnd();
            reader.Close();

            foreach(char data in _levelload) 
            {
                foreach(LevelElements element in elements) 
                {
                    if(data == element.key) 
                    {
                        GameObject temp = Instantiate(element.prefab);
                        temp.name = element.name;
                        temp.transform.position = new Vector3(_curX, _curY, _curZ);
                        _curX++;
                    }
                }

                // Espacio en blanco
                if (data == '-')
                {
                    _curX++;
                }

                // Salto de linea
                if (data == ',')
                {
                    _curZ--;
                    _curX = 0;
                }
            }
            yield return new WaitForEndOfFrame();
            _targets = SKGameControl.instance.GetTargets();
            _gameStart = true;
        }

        public bool GameStarted() 
        {
            return _gameStart;
        }
    }
}

