using UnityEngine;

public class CameraShotRayCaster : MonoBehaviour, IShotRayCaster
{
   private static readonly Vector3 ScreenCenterViewportPoint = new Vector3(0.5f, 0.5f, 0);

   [SerializeField] private Camera _camera;
   [SerializeField] private LayerMask _hitMask;

   public bool TryGetHit(float maxDistance, out RaycastHit hit)
   {
      Ray ray = _camera.ViewportPointToRay(ScreenCenterViewportPoint);
      
      return Physics.Raycast(ray, out hit, maxDistance, _hitMask);
   }
}