using UnityEngine;

namespace Progo.Player
{
    public sealed class FirstPersonCamera : MonoBehaviour
    {
        [SerializeField] private Transform playerBody;
        [SerializeField] private float sensitivity = 180f;
        [SerializeField] private float minPitch = -85f;
        [SerializeField] private float maxPitch = 85f;

        private float pitch;
        private bool lookEnabled = true;

        private void Start() => Cursor.lockState = CursorLockMode.Locked;

        private void Update()
        {
            if (!lookEnabled) return;

            float yaw = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mousePitch = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            pitch = Mathf.Clamp(pitch - mousePitch, minPitch, maxPitch);
            transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
            playerBody.Rotate(Vector3.up * yaw);
        }

        public void SetLookEnabled(bool enabled)
        {
            lookEnabled = enabled;
            Cursor.lockState = enabled ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
