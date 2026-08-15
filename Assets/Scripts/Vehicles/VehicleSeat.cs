using UnityEngine;
using Progo.Player;

namespace Progo.Vehicles
{
    public sealed class VehicleSeat : MonoBehaviour
    {
        [SerializeField] private Transform seatPoint;
        [SerializeField] private Transform exitPoint;
        [SerializeField] private VehicleDoor door;
        [SerializeField] private VehicleController vehicle;
        [SerializeField] private Camera vehicleCamera;

        private PlayerController occupant;
        private bool transitioning;

        public bool Occupied => occupant != null;

        public bool TryEnter(PlayerController player)
        {
            if (Occupied || transitioning || player == null) return false;
            transitioning = true;

            if (door != null) door.SetOpen(true);
            player.transform.SetPositionAndRotation(seatPoint.position, seatPoint.rotation);
            player.SetInputEnabled(false);
            occupant = player;
            if (vehicle != null) vehicle.SetDriving(true);
            if (vehicleCamera != null) vehicleCamera.enabled = true;

            if (door != null) door.SetOpen(false);
            transitioning = false;
            return true;
        }

        public bool TryExit()
        {
            if (!Occupied || transitioning) return false;
            transitioning = true;

            if (vehicle != null) vehicle.SetDriving(false);
            if (vehicleCamera != null) vehicleCamera.enabled = false;
            if (door != null) door.SetOpen(true);

            occupant.transform.SetPositionAndRotation(exitPoint.position, exitPoint.rotation);
            occupant.SetInputEnabled(true);
            occupant = null;

            if (door != null) door.SetOpen(false);
            transitioning = false;
            return true;
        }

        public PlayerController Occupant => occupant;
    }
}
