using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Vector3 PlanarForward => Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
    public Vector3 PlanarRight => Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized;
}