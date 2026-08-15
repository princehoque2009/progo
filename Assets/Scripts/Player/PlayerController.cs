using UnityEngine;

namespace Progo.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 4f;
        [SerializeField] private float sprintSpeed = 7f;
        [SerializeField] private float gravity = -20f;
        [SerializeField] private Transform cameraRoot;

        private CharacterController controller;
        private float verticalVelocity;
        private bool inputEnabled = true;

        public bool InputEnabled => inputEnabled;

        private void Awake() => controller = GetComponent<CharacterController>();

        private void Update()
        {
            if (!inputEnabled) return;

            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            input = Vector2.ClampMagnitude(input, 1f);

            float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            Vector3 forward = cameraRoot ? Vector3.ProjectOnPlane(cameraRoot.forward, Vector3.up).normalized : transform.forward;
            Vector3 right = cameraRoot ? cameraRoot.right : transform.right;
            Vector3 movement = (forward * input.y + right * input.x) * speed;

            if (controller.isGrounded && verticalVelocity < 0f) verticalVelocity = -2f;
            verticalVelocity += gravity * Time.deltaTime;
            movement.y = verticalVelocity;

            controller.Move(movement * Time.deltaTime);
        }

        public void SetInputEnabled(bool enabled)
        {
            inputEnabled = enabled;
            if (!enabled) verticalVelocity = 0f;
        }
    }
}
