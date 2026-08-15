using UnityEngine;
using Progo.Player;

namespace Progo.Vehicles
{
    public sealed class VehicleOccupantInput : MonoBehaviour
    {
        [SerializeField] private VehicleSeat seat;

        private void Update()
        {
            if (seat == null || !seat.Occupied) return;

            if (Input.GetKeyDown(KeyCode.F))
                seat.TryExit();
        }
    }
}
