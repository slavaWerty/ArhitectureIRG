using UnityEngine;

namespace Patterns.Arhitecture
{
    public class Player : MonoBehaviour
    {
        private void Update()
        {
            transform.position = new Vector3(transform.position.x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
        }
    }
}
