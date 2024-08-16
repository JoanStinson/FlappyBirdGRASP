using UnityEngine;

namespace JGM.Game
{
    public class RightCollider : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.CompareTag("Player"))
            {
                return;
            }

            collision.gameObject.GetComponent<Player>().TriggerRightHitEffect();
        }
    }
}
