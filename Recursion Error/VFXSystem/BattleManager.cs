using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static Dictionary<CyberneticSlot, VisualEffect> dictCyberneticVFX;
    public static BattleManager singleton;

    void Awake()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(gameObject);
            return;
        }

        singleton = this;
        DontDestroyOnLoad(gameObject);

        dictCyberneticVFX = new Dictionary<CyberneticSlot, VisualEffect>();
    }

    public static void AddCybernetic(Cybernetic cybernetic)
    {
        if (cybernetic.visualEffect != null)
        {
            if (dictCyberneticVFX.ContainsKey(cybernetic.slot))
            {
                singleton.playerController.StopCyberneticVFX(cybernetic.slot);
            }
            dictCyberneticVFX[cybernetic.slot] = cybernetic.visualEffect;
            singleton.playerController.AddCyberneticVFX(cybernetic.visualEffect, cybernetic.slot);
        }
    }

    public Dictionary<CyberneticSlot, VisualEffect> LoadCyberneticVFXs()
    {
        return new Dictionary<CyberneticSlot, VisualEffect>(dictCyberneticVFX);
    }
}