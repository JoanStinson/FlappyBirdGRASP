using UnityEngine;

namespace JGM.Game
{
    public class FloorView : MoverView
    {
        [SerializeField] private float m_movementSpeed = -1f;
        [SerializeField] private float m_rightLimit = 0f;
        [SerializeField] private float m_leftLimit = -10f;

        protected override void Move()
        {
            float newXPosition = transform.localPosition.x + m_movementSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);

            if (transform.localPosition.x <= m_leftLimit)
            {
                transform.localPosition = new Vector3(m_rightLimit, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}
