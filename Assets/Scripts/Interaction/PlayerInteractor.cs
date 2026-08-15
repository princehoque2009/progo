using UnityEngine;
using Progo.Player;
using Progo.Vehicles;

namespace Progo.Interaction
{
    public sealed class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private Camera viewCamera;
        [SerializeField] private PlayerController player;
        [SerializeField] private float interactionDistance = 3f;
        [SerializeField] private LayerMask interactionMask = ~0;

        private void Update()
        {
            if (player == null || !player.InputEnabled) return;
            if (!Input.GetKeyDown(KeyCode.E)) return;

            if (!Physics.Raycast(viewCamera.transform.position, viewCamera.transform.forward, out RaycastHit hit, interactionDistance, interactionMask))
                return;

            VehicleSeat seat = hit.collider.GetComponentInParent<VehicleSeat>();
            if (seat != null)
            {
                seat.TryEnter(player);
            }
        }
    }
}
