using UnityEngine;

namespace JGM.Game
{
    public class Player : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) ||
                Input.GetKeyDown(KeyCode.Space))
            {
                OnTap();
            }
        }

        private void OnTap()
        {
            Debug.Log("Tap or click detected!");
        }
    }
}