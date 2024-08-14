using UnityEngine;

namespace JGM.Game
{
    public class Player : MonoBehaviour
    {
        private void Update()
        {
            var playerInput = new PlayerInputBuilder().GetPlayerInput();
            if (playerInput.Pressed())
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