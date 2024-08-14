using UnityEngine;

namespace JGM.Game
{
    public class Pipe : MonoBehaviour
    {
        private void Update()
        {
            transform.position -= Vector3.right * Time.deltaTime;
        }
    }
}
