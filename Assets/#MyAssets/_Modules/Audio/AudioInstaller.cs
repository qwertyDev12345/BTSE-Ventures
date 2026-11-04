using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    public AudioPlayer audioPlayerPrefab;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AudioPlayer>().FromComponentInNewPrefab(audioPlayerPrefab).AsSingle().NonLazy();
    }
}