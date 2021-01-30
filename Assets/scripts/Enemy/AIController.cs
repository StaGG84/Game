using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {

    public GameManager GM;
    ObjectParam Params;
    public WeaponBase Weapon;
    public GameObject Target;
    private bool bt_enable = true;
    private CharacterController m_characterController;
    private NavMeshAgent m_navMeshAgent;

    public enum States { IDLE, MOVE, ATTACK, DEAD };
    public States state = States.IDLE;

    public Material material;
    public Animator anim;
    private BotHealthBarController HealthBar;



    // Use this for initialization
    void Start() {

        Params = GetComponent<ObjectParam>();
        m_characterController = GetComponent<CharacterController>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        HealthBar = GetComponent<BotHealthBarController>();
        Weapon = GetComponent<WeaponBase>();

        state = States.IDLE;

        Params.SetRunSpeed(Params.GetMoveSpeed() * 2f);
        Params.SetAttackSpeed(Weapon.GetCooldown() + Weapon.GetActionTime());

        material = GetComponent<Renderer>().material;

        ChangeHealth();

    }

    public void Move(GameObject trgt)
    {
        SetAnimSate(States.MOVE);
        m_navMeshAgent.isStopped = false;
        //Vector3 forvard = transform.TransformDirection(Vector3.forward);

        //m_characterController.Move(forvard * Params.GetMoveSpeed() * Time.deltaTime);
        m_navMeshAgent.SetDestination(trgt.transform.position);
    }
    public void Rotate(Vector3 rotate)
    {
    }
    public void LookAtTarget(GameObject trgt)
    {
        this.transform.LookAt(trgt.transform);
    }
    public void Attack() {
        LookAtTarget(Target);
        m_navMeshAgent.isStopped = true;
        if (Weapon.Attack(Target)) SetAnimSate(States.ATTACK);
    }
    public void Dead() {
        bt_enable = false;
        SetAnimSate(States.DEAD);
        StartCoroutine(ObjectDestroy());
        IEnumerator ObjectDestroy()
        {
            yield return new WaitForSeconds(Params.GetCorpseLifeTime());

            Destroy(this.gameObject);
        }
    }
    public void Stay()
    {
        SetAnimSate(States.IDLE);
        m_navMeshAgent.isStopped = true;
    }

    void SetAnimSate(States stt) {
        state = stt;
        switch (stt)
        {
            case States.IDLE:
                anim.SetBool("IDLE", true);
                anim.SetBool("MOVE", false);
                anim.SetBool("ATTACK", false);
                anim.SetBool("DEAD", false);
                Debug.Log("IDLE");
                break;
            case States.MOVE:
                anim.SetBool("IDLE", false);
                anim.SetBool("MOVE", true);
                anim.SetBool("ATTACK", false);
                anim.SetBool("DEAD", false);
                Debug.Log("MOVE");
                break;
            case States.ATTACK:
                anim.SetBool("IDLE", false);
                anim.SetBool("MOVE", false);
                anim.SetBool("ATTACK", true);
                anim.SetBool("DEAD", false);
                Debug.Log("ATTACK");
                break;
            case States.DEAD:
                anim.SetBool("IDLE", false);
                anim.SetBool("MOVE", false);
                anim.SetBool("ATTACK", false);
                anim.SetBool("DEAD", true);
                Debug.Log("DEAD");
                break;
            default:
                break;
        }


    }

    void SetTeamColor()
    {
        if (Params.GetTeam() == GameManager.Teams.TEAM1)
        {
            HealthBar.SetTeamColor (Color.red);
        }
        else
        {
            HealthBar.SetTeamColor(Color.blue);
        }

    }



    bool TargetIsValid() {
        return !(!Target || Target.GetComponent<ObjectParam>().GetIsDead());
    }

    void GetNewTarget()
    {
        bool getNewTarget = false;

        if (GM)
        {
            if (!TargetIsValid() && GM.GetGameState() == GameManager.GameState.BATTLE)
                getNewTarget = true;
        }

        if (getNewTarget) {
            List<GameObject> ValidTargetList = new List<GameObject>();

            foreach (GameObject go in GM.ObjectList)
                if (go)
                    if (!go.GetComponent<ObjectParam>().GetIsDead() && go.GetComponent<ObjectParam>().GetTeam() != this.GetComponent<ObjectParam>().GetTeam())
                        if (!TargetIsValid())
                            Target = go;
                        else
                            if (Vector3.Distance(transform.position, Target.transform.position) > Vector3.Distance(transform.position, go.transform.position))
                            Target = go;
        }


    }
    void MoveTo(GameObject trgt) {
        LookAtTarget(Target);
        Move(Target);
    }

    void BehaviourTree() {

        if (!bt_enable) return;

        if (!TargetIsValid()) // Нет цели или цель мертвая - стоим
        {
            Stay();
            GetNewTarget();
            return;
        }

        if ((Vector3.Distance(transform.position, Target.transform.position) > Weapon.GetRange())) // Не дотягиваемся - идем
            MoveTo(Target);
        else // Дотягиваемся - бьем
            Attack();
    }




    public void ChangeHealth (){
        HealthBar.UpdateHealthBar(Params.GetCurrentHealth(), Params.GetMaxHealth());
    }
    public void ObjectIsDead()
    {
        Dead();
    }



    void Update () {
        BehaviourTree();
        SetTeamColor();
    }





}
