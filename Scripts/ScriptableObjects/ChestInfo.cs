using UnityEngine;

namespace Patterns.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChestInfo", menuName = "Game/New ChestInfo")]
    public class ChestInfo : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private GameObject _prepaf;

        public string Id => _id;
        public GameObject Prepaf => _prepaf;
    }
}
