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
            if(_gameStart) {
                foreach(SKTarget target in _targets) {
                    //_gameDone = target.GetStatus();
                }
            }
        }

        private IEnumerator InitGame()
        {
            _curX = 0;
            _curY = 0;
            _curZ = 0;

            // Lectura del archivo
            string path = Application.dataPath + "/StreamingAssets/" + levelName + ".txt";
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

                if (data == ',')
                {
                    _curZ--;
                    _curX = 0;
                }
                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
            _gameStart = true;
            _targets = SKGameControl.instance.GetTargets();
        }
    }
}

