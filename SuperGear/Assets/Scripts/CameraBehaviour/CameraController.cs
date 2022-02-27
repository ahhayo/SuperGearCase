using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {

        public float xRot = 0f;
        public float yRot = 0f;

        public float distance = 5f;
        public float sensitivity = 1000f;

        public Transform target;

        void Update()
        {
            if (!Input.GetMouseButton(0))
                return;
            xRot += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            yRot += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            if (xRot > 90f)
            {
                xRot = 90f;
            }
            else if (xRot < -90f)
            {
                xRot = -90f;
            }

            transform.position = target.position + Quaternion.Euler(xRot, yRot, 0f) * (distance * -Vector3.back);
            transform.LookAt(target.position, Vector3.up);
        }

    }




}
