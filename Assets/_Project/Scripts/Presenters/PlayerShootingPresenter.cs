using System;
using R3;
using UnityEngine;
using Zenject;

public class PlayerShootingPresenter : IInitializable, IDisposable
{
    private readonly PlayerInputView _inputView;
    private readonly RangedWeapon _weapon;
    private readonly IShotRayCaster _shotRayCaster;
    private readonly CompositeDisposable _subscriptions = new CompositeDisposable();

    public PlayerShootingPresenter(PlayerInputView playerInputView, RangedWeapon rangedWeapon, IShotRayCaster shotRayCaster)
    {
        _inputView = playerInputView;
        _weapon = rangedWeapon;
        _shotRayCaster = shotRayCaster;
    }

    public void Initialize()
    {
        _inputView.FirePressed.Subscribe(_ => _weapon.PullTrigger()).AddTo(_subscriptions);
        _weapon.Fired.Subscribe(_ => HandleShot()).AddTo(_subscriptions);
    }

    public void Dispose()
    {
        _subscriptions.Dispose();
    }

    private void HandleShot()
    {
        if (_shotRayCaster.TryGetHit(_weapon.Range, out RaycastHit hit))
        {
            Debug.Log($"Выстрел попали в {hit.collider.name}");
            return;
        }
        Debug.Log($"промах");
    }
}