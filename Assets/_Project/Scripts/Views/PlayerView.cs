using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerView : MonoBehaviour
{
    private const float GroundedVerticalVelocity = -2f;

    [SerializeField] private float _gravity = -20f;
    [SerializeField] private float _rotationSpeedDegrees = 720f;
    
    private CharacterController _characterController;
    private float _verticalVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 horizontalVelocity)
    {
        ApplyGravity();
        
        Vector3 velocity = horizontalVelocity + Vector3.up * _verticalVelocity;
        _characterController.Move(velocity * Time.deltaTime);
    }

    public void RotateTowards(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;
        
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation
            ,_rotationSpeedDegrees * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _verticalVelocity < GroundedVerticalVelocity)
            _verticalVelocity = GroundedVerticalVelocity;
        
        _verticalVelocity += _gravity * Time.deltaTime;
    }
}