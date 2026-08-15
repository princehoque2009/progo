using UnityEngine;

namespace Progo.Vehicles
{
    public sealed class VehicleController : MonoBehaviour
    {
        [SerializeField] private Rigidbody body;
        [SerializeField] private float engineForce = 9000f;
        [SerializeField] private float brakeForce = 5000f;
        [SerializeField] private float steeringTorque = 1800f;
        [SerializeField] private float maxSpeed = 35f;

        private bool driving;

        public bool IsDriving => driving;

        private void FixedUpdate()
        {
            if (!driving || body == null) return;

            float throttle = Input.GetAxis("Vertical");
            float steering = Input.GetAxis("Horizontal");
            Vector3 localVelocity = transform.InverseTransformDirection(body.linearVelocity);

            if (localVelocity.z < maxSpeed || throttle < 0f)
                body.AddForce(transform.forward * throttle * engineForce * Time.fixedDeltaTime, ForceMode.Force);

            if (Input.GetKey(KeyCode.Space))
                body.AddForce(-transform.forward * Mathf.Max(localVelocity.z, 0f) * brakeForce * Time.fixedDeltaTime, ForceMode.Force);

            float speedFactor = Mathf.Clamp01(body.linearVelocity.magnitude / 5f);
            body.AddTorque(Vector3.up * steering * steeringTorque * speedFactor * Time.fixedDeltaTime, ForceMode.Force);
        }

        public void SetDriving(bool value) => driving = value;
    }
}
