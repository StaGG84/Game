using UnityEngine;
using System.Collections;

public class WeaponBase {

    float       m_damage;
    float       m_actiontime;
    float       m_cooldown;
    float       m_range;
    float       m_shotdelay;
    bool        m_canMove;




    public float Damage             { get { return m_damage; } }
    public float ActionTime         { get { return m_actiontime; } }
    public float Cooldown           { get { return m_cooldown; } }
    public float Range              { get { return m_range; } }
    public float ShotDelay          { get { return m_shotdelay; } }
    public float AttackSpeed        { get { return m_actiontime + m_cooldown; } }
    public bool CanMove             { get { return m_canMove; } }

    public float            attackTimer;

    public ObjectParam 			Params;

    // Use this for initialization

  
    public void Init (ObjectParam ownerParam) {
        Params          = ownerParam;
        m_damage        = 10;
        m_actiontime    = 2;
        m_cooldown      = 0;
        m_range         = 3;
        m_shotdelay     = 1;
        m_canMove       = false;

    }


/*Attack ========================================================================*/
public bool CreateBullet(GameObject target)
    {
        if (target.gameObject.GetComponent<BuffList>())
        {
            target.gameObject.GetComponent<BuffList>().AddBuff(Params, BuffList.Buff.EBuffType.HP, BuffList.Buff.ETargetTeam.ENEMY, -Damage, 0, 0);
            return true;
        }
        else
        {
            return false;
        }
    }

}
