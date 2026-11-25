using R3;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputView : MonoBehaviour
{
   private GameInput _gameInput;
   
   public Observable<Unit> FirePressed {get; private set;}

   private void Awake()
   {
      _gameInput = new GameInput();
      
      FirePressed = Observable.FromEvent<InputAction.CallbackContext>(handler => _gameInput.Player.Fire.performed += handler
      ,handler => _gameInput.Player.Fire.performed -= handler).Select(_ => Unit.Default);
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