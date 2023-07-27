using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
	public List<string> scenes;
	public string targetScene;

	public void ChangeScene()
	{
		EnemyHealthbarManager.CleanUpHealthbars();

		if (targetScene != "")
        {
			if (targetScene == "Inside1")
            {
				BattleManager.singleton.playedInside1 = true;
            }
			else if (targetScene == "Inside2")
            {
				BattleManager.singleton.playedInside2 = true;
			}
			else if (targetScene == "Boss Scene")
            {
				BattleManager.singleton.currentArea = Area.BOSS;
			}
			SetUpNextScene(targetScene);
		}
        else
        {
			string sceneToTransportTo = "Hub_Scene";
			if (scenes.Count >= 1)
			{
				sceneToTransportTo = scenes[Random.Range(0, scenes.Count)];
				scenes.Remove(sceneToTransportTo);
				BattleManager.singleton.SetScenesAvailable(scenes);
			}
			else
			{
				if (BattleManager.singleton.currentArea == Area.DOCK)
				{
					SetScenes(BattleManager.singleton.cityScenes);
					sceneToTransportTo = scenes[Random.Range(0, scenes.Count)];
					scenes.Remove(sceneToTransportTo);
					BattleManager.singleton.SetScenesAvailable(scenes);
					BattleManager.singleton.currentArea = Area.CITY;
				}
				else if (BattleManager.singleton.currentArea == Area.CITY)
                {
					BattleManager.singleton.SetScenesAvailable(scenes);
					BattleManager.singleton.currentArea = Area.BUILDING;
					sceneToTransportTo = "PreBossHub";
				}
			}

			SetUpNextScene(sceneToTransportTo);
        }
	}

	public void SetScenes(List<string> newScenes)
    {
		scenes = new List<string>(newScenes);
	}

	private void SetUpNextScene(string targetScene)
    {
		EnemyHealthbarManager.singleton.isActive = true;
		BattleManager.singleton.SetCurrentHealth();
		BattleManager.singleton.currentSceneChanger = null;
		SceneChangeManager.singleton.ChangeScene(targetScene);
	}
}