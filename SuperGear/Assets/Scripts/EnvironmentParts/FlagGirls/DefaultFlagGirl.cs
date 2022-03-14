using UnityEngine;

namespace Assets.Scripts.EnvironmentParts.FlagGirls
{
    public class DefaultFlagGirl : MonoBehaviour
    {
        public Animator anim;
        [SerializeField] private float animationDelayInMilliSeconds = 1750f;
        public void Start()
        {
            if (!anim)
                anim = GetComponent<Animator>();
            GameManager.instance.Race.CountDownChanged += WaitCounter;
        }

        public void WaitCounter(float RemainedMilliseconds)
        {
            if (RemainedMilliseconds > animationDelayInMilliSeconds)
                return;

            TriggerStartAnim();
            GameManager.instance.Race.CountDownChanged -= WaitCounter;
        }

        public void TriggerStartAnim()
        {
            anim.SetTrigger("StartRace");
        }

    }
}
