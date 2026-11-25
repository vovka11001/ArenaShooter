using UnityEngine;

public class PlayerInputView : MonoBehaviour
{
   private GameInput _gameInput;

   private void Awake()
   {
      _gameInput = new GameInput();
   }

   private void OnEnable()
   {
      _gameInput.Enable();
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
   }

   private void OnDisable()
   {
      _gameInput.Disable();
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
   }

   private void OnDestroy()
   {
      _gameInput.Dispose();
   }

   public Vector2 ReadMoveInput()
   {
      return _gameInput.Player.Move.ReadValue<Vector2>();
   }
}