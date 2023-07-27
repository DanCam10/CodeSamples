using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "Dash Shield", menuName = "CyberneticSO/DashShield")]
public class DashShield : Cybernetic
{
    public float shieldUpTime;
    public float shieldCooldown;

    private bool shieldIsReady = true;

    public override void AssignTriggers()
    {
        base.AssignTriggers();

        triggers[(int)CyberneticTriggers.PLAYER_DASHES] = true;
        triggerFunctions[(int)CyberneticTriggers.PLAYER_DASHES] += AddShieldAfterDash;
        shieldIsReady = true;
    }

    /// <summary>
    /// Adds a shield to the player after they perform a dash
    /// </summary>
    /// <param name="enemy"></param>
    public void AddShieldAfterDash(EnemyDemo enemy)
    {
        if (shieldIsReady)
        {
            BattleManager.singleton.StartCybrCoroutine(AddShieldCoroutine());
            BattleManager.singleton.StartCybrCoroutine(SetShieldCooldownCoroutine());
        }
    }

    
    private IEnumerator AddShieldCoroutine()
    {
        BattleManager.singleton.playerController.PlayCyberneticVFX(CyberneticSlot.LEGS);
        BattleManager.singleton.playerHealth.playerHasShield = true;
        yield return new WaitForSeconds(shieldUpTime);
        BattleManager.singleton.playerController.StopCyberneticVFX(CyberneticSlot.LEGS);
        BattleManager.singleton.playerHealth.playerHasShield = false;
    }

    private IEnumerator SetShieldCooldownCoroutine()
    {
        shieldIsReady = false;
        PlayerEquipmentUI.TriggerCooldown(this, shieldCooldown);
        yield return new WaitForSeconds(shieldCooldown);
        shieldIsReady = true;
    }
    

    private void OnDestroy()
    {
        triggerFunctions[(int)CyberneticTriggers.PLAYER_DASHES] -= AddShieldAfterDash;
    }
}
