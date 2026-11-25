using UnityEngine;

public interface IShotRayCaster
{
    bool TryGetHit(float maxDistance, out RaycastHit hit);
}