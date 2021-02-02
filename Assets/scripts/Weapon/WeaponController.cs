using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    public enum EAnimState
    {
        AIM,
        FIRE,
        IDLE,
        RELOAD,
        RUN,
        RELOAD_SHOOTGUN,

        INVALID
    }

    public enum EWeaponFilterType
    {
        PISTOL,
        UMP,
        RIFLE,
        SHOTGUN,
        SNIPER,
        MELEE,
        GRENADE
    }

    public enum EWeaponShootType
    {
        RAY,
        BULLET,
        GUIDED_BULLET
    }

    public class WeaponController : MonoBehaviour
    {
        //public ParticleSystem m_shootDelayEffectPref;
        //public EWeaponShootType m_shootType = EWeaponShootType.RAY;
        //public WeaponView                 m_viewPref;
        //public Sprite m_icon;
        //public TargeringModule            m_targetingPref;
        //public bool m_activeOnlyInSuccessHit = false;
        //public AudioSource m_equippedSoundSource;



        WeaponBase m_baseWeapon;
        float m_lastAttackTime;


        float m_traceDist = 0f;
        bool m_inFire = false;
        GameObject m_target;
        EAnimState m_animState;



        //--------------------------------------------------------------------------------------
        public float Range
        {
            get
            {
                return m_traceDist;
            }
        }
        public GameObject Target
        {
            get
            {
                return m_target;
            }

            set
            {
                m_target = value;
            }
        }
        /*public WeaponView View
            {
              get
              {
                return Slot.WeaponView;
              }
            }*/
        public bool CanMove
        {
            get
            {
                if (IsInFire)
                    return WeaponBase.CanMove;

                return true;
            }
        }
        public bool IsInFire
        {
            get
            {
                return m_inFire;
            }
        }
        public bool IsEnable
        {
            get;
            set;
        }
        public WeaponBase WeaponBase
        {
            get
            {
                return m_baseWeapon;
            }
        }
        public float BeginFireTime
        {
            get;
            private set;
        }
        public float ShootDelayProgress
        {
            get
            {
                if (!IsInFire)
                    return 0f;

                float shootDelay = WeaponBase.ShotDelay;
                if (shootDelay == 0f)
                    return 0f;

                float progress = 1f - (shootDelay - (Time.time - BeginFireTime)) / shootDelay;
                return progress;
            }
        }
        public void Init()
        {

            ObjectParam ownerParam = GetComponent<ObjectParam>();

            m_baseWeapon = new WeaponBase();

            IsEnable = true;

            WeaponBase.Init(ownerParam);

            m_traceDist = WeaponBase.Range;

            //InitVisual();
        }
        public bool IsCanFire()
        {
            return true;
        }
        public void SetAnimState(EAnimState state)
        {
            m_animState = state;
        }
        public void Attack(GameObject trgt)
        {
            if (!trgt)
                return;
            else
                Target = trgt;

            if (!IsEnable)
                return;

            if (IsCanFire())
            {
                BeginFire();
            }
        }
        public void BeginFire()
        {
            if (!IsCanFire())
                return;

            if (!IsEnable)
                return;

            if (m_inFire)
                return;

            //m_inFire = true;
            BeginFireTime = Time.time;

            if (Target && ((Time.time - m_lastAttackTime) >= (WeaponBase.AttackSpeed)))
            {
                StartCoroutine(AttackAfterDelay());

                m_lastAttackTime = Time.time;
            }

        }
        IEnumerator AttackAfterDelay()
        {
            yield return new WaitForSeconds(WeaponBase.ShotDelay);
            WeaponBase.CreateBullet(Target);
        }


    }

