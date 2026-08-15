using UnityEngine;

namespace Progo.Vehicles
{
    public sealed class VehicleDoor : MonoBehaviour
    {
        [SerializeField] private Transform hinge;
        [SerializeField] private float openAngle = -65f;
        [SerializeField] private float animationSpeed = 7f;

        private Quaternion closedRotation;
        private Quaternion targetRotation;

        private void Awake()
        {
            if (hinge == null) hinge = transform;
            closedRotation = hinge.localRotation;
            targetRotation = closedRotation;
        }

        private void Update()
        {
            hinge.localRotation = Quaternion.Slerp(hinge.localRotation, targetRotation, animationSpeed * Time.deltaTime);
        }

        public void SetOpen(bool open)
        {
            targetRotation = open
                ? closedRotation * Quaternion.Euler(0f, openAngle, 0f)
                : closedRotation;
        }
    }
}
