using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
[CreateAssetMenu(fileName = "MyScriptableInstaller", menuName = "MyScriptableInstaller")]
public class MyScriptableInstaller :  ScriptableObjectInstaller
{
    [SerializeField] private MapSettings _mapSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(_mapSettings);
        Container.BindInterfacesTo<MapDynamic>().AsSingle();
    }
}
