using UnityEngine;

namespace Patterns.Arhitecture
{
    public class Tester : MonoBehaviour
    {    
        private void Start()
        {
            Game.Run();
        }

        private void Update()
        {
            if (!Bank.IsInitzialize)
                return;


            if (Input.GetKeyDown(KeyCode.E))
            {
                Bank.AddCoins(this, 5);
                Debug.Log(Bank.coins);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Bank.Spend(this, 5);
                Debug.Log(Bank.coins);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                DestroyObject(Game.GetInteractor<PlayerInteractor>().player.gameObject, false);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                DestroyObject(Game.GetInteractor<PlayerInteractor>().player.gameObject, true);
            }
        }

        public void DestroyObject(GameObject go, bool active)
        {
            go.SetActive(active);
        }
    }
}
