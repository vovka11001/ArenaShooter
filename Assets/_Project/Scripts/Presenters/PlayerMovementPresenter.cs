using System;
using R3;
using UnityEngine;
using Zenject;

public class PlayerMovementPresenter : IInitializable, IDisposable
{
   private readonly GameConfig _config;
   private readonly PlayerInputView _inputView;
   private readonly CameraView _cameraView;
   private readonly PlayerView _playerView;
   private readonly CompositeDisposable _subscriptions = new CompositeDisposable();

   public PlayerMovementPresenter(GameConfig config, PlayerInputView inputView, CameraView cameraView,
      PlayerView playerView)
   {
      _config = config;
      _inputView = inputView;
      _cameraView = cameraView;
      _playerView = playerView;
   }

   public void Initialize()
   {
      Observable.EveryUpdate().Subscribe(_ => UpdateMovement()).AddTo(_subscriptions);
   }

   public void Dispose()
   {
      _subscriptions.Dispose();
   }

   private void UpdateMovement()
   {
      Vector2 moveInput = _inputView.ReadMoveInput();
      Vector3 cameraForward = _cameraView.PlanarForward;
      Vector3 moveDirection = cameraForward * moveInput.y + _cameraView.PlanarRight * moveInput.x;
      
      _playerView.Move(moveDirection * _config.PlayerMoveSpeed);
      _playerView.RotateTowards(cameraForward);
   }
}