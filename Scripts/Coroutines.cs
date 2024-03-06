using System.Collections;
using UnityEngine;

namespace Patterns.Arhitecture
{
    public sealed class Coroutines : MonoBehaviour
    {
        private static Coroutines Instance 
        {
            get
            {
                if(MInstance == null)
                {
                    var go = new GameObject(name: "[Coroutine Manager]");
                    MInstance = go.AddComponent<Coroutines>();
                    DontDestroyOnLoad(go);
                }
                return MInstance;
            }
        }

        private static Coroutines MInstance;

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return Instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine coroutine)
        {
            Instance.StopCoroutine(coroutine);
        }
    }
}
