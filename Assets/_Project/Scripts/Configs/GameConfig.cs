using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private float _playerMoveSpeed = 5f;
    
    public float PlayerMoveSpeed => _playerMoveSpeed;
}