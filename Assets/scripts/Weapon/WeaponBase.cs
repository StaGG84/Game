using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour  {

	public float 			damage;
    public float 			actionTime;
    public float 			cooldown;
    public float            range;
    public float            attackTimer;

    public ObjectParam 			Params;

    // Use this for initialization

    void Start() {
        damage = 10f;
        actionTime = 0.5f;
        cooldown = 0.5f;
        range = 3f;
        attackTimer = 0f;
        Params = GetComponent<ObjectParam>();

    }
    
    
    public void Init () {
        

    }


    /*Range =========================================================================*/
    public float GetRange()
    {
        return range;
    }
    public void SetRange(float i)
    {
        range = i;
    }
    public void AddRange(float i)
    {
        range += i;
    }
    /*===============================================================================*/

    /*ActionTime =========================================================================*/
    public float GetActionTime()
    {
        return actionTime;
    }
    public void SetActionTime(float i)
    {
        actionTime = i;
    }
    public void AddActionTime(float i)
    {
        actionTime += i;
    }
    /*===============================================================================*/

    /*ActionTime =========================================================================*/
    public float GetCooldown()
    {
        return cooldown;
    }
    public void SetCooldown(float i)
    {
        cooldown = i;
    }
    public void AddCooldown(float i)
    {
        cooldown += i;
    }
    /*===============================================================================*/



    /*Attack ========================================================================*/
    public bool Attack (GameObject target)
    {
        if (target && ((Time.time - attackTimer) >= (actionTime + cooldown)))
        {
            if (target.gameObject.GetComponent<BuffList>())
            {
                target.gameObject.GetComponent<BuffList>().AddBuff(Params, BuffList.Buff.EBuffType.HP, BuffList.Buff.ETargetTeam.ENEMY, -damage, 0, 0);
            }
            attackTimer = Time.time;
            return true;
        }
        else { return false; }
    }
    /*===============================================================================*/

}
