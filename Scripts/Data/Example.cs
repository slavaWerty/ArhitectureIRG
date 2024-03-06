using UnityEngine;

namespace Patterns.Save
{
    public class Example : MonoBehaviour
    {
        public GameObject cube;

        private Storage _storage;
        private GameData _gameData;

        private void Start()
        {
            _storage = new Storage();
            Load();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Load();
            }
        }

        private void Save()
        {
            _gameData.position = cube.transform.position;
            _gameData.rotation = cube.transform.rotation;
            _storage.Save(_gameData);
            Debug.Log("Save");
        }

        private void Load()
        {
            _gameData = (GameData)_storage.Load(new GameData());

            cube.transform.position = _gameData.position;
            cube.transform.rotation = _gameData.rotation;
            Debug.Log(_gameData.speed);
            Debug.Log("Load");
        }
    }
}
