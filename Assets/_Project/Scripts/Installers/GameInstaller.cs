using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private PlayerInputView _playerInputView;
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private CameraShotRayCaster _shotRayCaster;
    
    public override void InstallBindings()
    {
        BindConfigs();
        BindPlayer();
    }

    private void BindConfigs()
    {
        Container.BindInstance(_gameConfig);
    }

    private void BindPlayer()
    {
        Container.BindInstance(_playerInputView);
        Container.BindInstance(_cameraView);
        Container.BindInstance(_playerView);
        Container.BindInterfacesTo<PlayerMovementPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<RangedWeapon>().AsSingle();
        Container.Bind<IShotRayCaster>().FromInstance(_shotRayCaster);
        Container.BindInterfacesTo<PlayerShootingPresenter>().AsSingle();
    }
}