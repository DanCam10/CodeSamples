using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public enum Area
{
    DOCK,
    CITY,
    BUILDING,
    BOSS
}

public class BattleManager : MonoBehaviour
{
    public Area currentArea = Area.DOCK;
    public List<string> scenesAvailable;
    public List<string> dockScenes;
    public List<string> cityScenes;

    public void SetScenesAvailable(List<string> newScenes)
    {
        scenesAvailable = new List<string>(newScenes);
    }
}