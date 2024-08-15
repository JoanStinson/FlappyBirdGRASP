using UnityEngine;

namespace JGM.Game
{
    public class InfiniteScroller : MonoBehaviour
    {
        [SerializeField] private float m_scrollSpeed = -1f;
        [SerializeField] private float m_rightEdge = 0f;
        [SerializeField] private float m_leftEdge = -10f;

        private void Update()
        {
            float newXPosition = transform.localPosition.x + m_scrollSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);

            if (transform.localPosition.x <= m_leftEdge)
            {
                transform.localPosition = new Vector3(m_rightEdge, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}
