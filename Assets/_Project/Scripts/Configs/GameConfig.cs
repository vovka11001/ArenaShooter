using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private float _playerMoveSpeed = 5f;
    [SerializeField] private float _fireCooldownSeconds = 0.25f;
    [SerializeField] private float _shotRange = 100f;
    
    public float PlayerMoveSpeed => _playerMoveSpeed;
    public float FireCooldownSeconds => _fireCooldownSeconds;
    public float ShotRange => _shotRange;
}