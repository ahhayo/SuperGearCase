using Cinemachine;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {

        public CinemachineFreeLook FollowerCam;

        public void FollowAndLookat(Transform tr)
        {
            FollowerCam.m_Follow = tr;
            FollowerCam.m_LookAt = tr;
        }

    }




}
