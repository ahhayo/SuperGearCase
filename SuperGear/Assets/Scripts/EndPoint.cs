using UnityEngine;

namespace Assets.Scripts
{
    public class EndPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!GameManager.instance.Race.RaceEnded)
                GameManager.instance.Race.RaceEnded = true;
        }
    }
}
