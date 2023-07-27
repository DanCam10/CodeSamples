using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.VFX;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerDemo : MonoBehaviour
{
    public Dictionary<CyberneticSlot, VisualEffect> dictCyberneticVFX;

    // Start is called before the first frame update
    void Start()
    {
        dictCyberneticVFX = BattleManager.singleton.LoadCyberneticVFXs();
    }

    public void AddCyberneticVFX(VisualEffect newEffect, CyberneticSlot slot)
    {
        dictCyberneticVFX[slot] = newEffect;
        Instantiate(newEffect.gameObject, transform);
    }

    public void PlayCyberneticVFX(CyberneticSlot slot)
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains(dictCyberneticVFX[slot].name))
            {
                child.GetComponent<VisualEffect>().Play();
                break;
            }
        }
    }

    public void StopCyberneticVFX(CyberneticSlot slot)
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains(dictCyberneticVFX[slot].name))
            {
                child.GetComponent<VisualEffect>().Reinit();
                break;
            }
        }
    }

    public VisualEffect GetCyberneticVFX(CyberneticSlot slot)
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains(dictCyberneticVFX[slot].name))
            {
                return child.GetComponent<VisualEffect>();
            }
        }
        return new VisualEffect();
    }

    private void AddAllCyberneticVFX()
    {
        foreach (KeyValuePair<CyberneticSlot, VisualEffect> entry in dictCyberneticVFX)
        {
            if (entry.Value != null)
            {
                Instantiate(entry.Value.gameObject, transform);
            }
        }
    }
}