using UnityEngine;

namespace JGM.Game
{
    public class BottomColliderView : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerView>().TriggerDownHitEffect();
            }
        }
    }    
}
