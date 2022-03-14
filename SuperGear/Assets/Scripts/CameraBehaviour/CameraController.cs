using Cinemachine;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public CinemachineFreeLook FollowerCam;
        private CinemachineVirtualCameraBase currentCam;

        public CinemachineVirtualCameraBase CurrentCam
        {
            get { return currentCam; }
            set
            {
                if (currentCam)
                    currentCam.Priority = 0;
                currentCam = value;
                if (currentCam)
                    currentCam.Priority = 10;
            }
        }


        private void Start()
        {
            CinemachineCore.GetInputAxis = GetAxisCustom;
            CurrentCam = FollowerCam;
        }
        private float GetAxisCustom(string axisName)
        {
            if (axisName == "Mouse X")
            {
                if (Input.GetMouseButton(1))
                {
                    return Input.GetAxis("Mouse X");
                }
                else
                {
                    return 0;
                }
            }
            else if (axisName == "Mouse Y")
            {
                if (Input.GetMouseButton(1))
                {
                    return Input.GetAxis("Mouse Y");
                }
                else
                {
                    return 0;
                }
            }
            return Input.GetAxis(axisName);
        }

        public void FollowAndLookat(Transform tr)
        {
            FollowerCam.m_Follow = tr;
            FollowerCam.m_LookAt = tr;
        }

    }




}
