using UnityEngine;

namespace JGM.Game
{
    public class RotateCommand : PlayerCommand
    {
        [SerializeField] private Rigidbody2D m_rigidbody2D;
        [SerializeField] private float m_pitchAngle = 12f;
        [SerializeField] private float m_rotationSpeed = 6f;

        public override void Execute()
        {
            float targetAngle = (m_rigidbody2D.velocity.y > 0) ? m_pitchAngle : -m_pitchAngle;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_rotationSpeed * Time.deltaTime);
        }
    }
}
