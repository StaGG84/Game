using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {

    public GameManager GM;
    ObjectParam Params;
    private WeaponBase Weapon;
    public GameObject Target;
    private bool bt_enable = true;
    private CharacterController m_characterController;
    private NavMeshAgent m_navMeshAgent;

    public enum States { IDLE = 1, MOVE = 2, ATTACK = 3, DEAD = 0 };
    public States state = States.IDLE;

    public Material material;
    public Animator anim;
    private BotHealthBarController HealthBar;

    public List<GameObject> ModelList = new List<GameObject>();



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
        SetModel();



    }

    void SetModel() {

        GameObject slaveModel = Instantiate(ModelList[Random.Range(0, ModelList.Count)]);
        slaveModel.transform.SetParent(transform);
        slaveModel.transform.localPosition = new  Vector3 (0, 0, 0);

        anim = slaveModel.GetComponent<Animator>();

    }

    void SetState(States botState)
    {
        state = botState;
        anim.SetInteger("STATE", (byte) botState);
    }
    
    public void Move(GameObject trgt)
    {
        SetState(States.MOVE);
        m_navMeshAgent.isStopped = false;
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
        if (Weapon.Attack(Target)) SetState(States.ATTACK);
    }
    public void Dead() {
        bt_enable = false;
        SetState(States.DEAD);
        StartCoroutine(ObjectDestroy());
        IEnumerator ObjectDestroy()
        {
            yield return new WaitForSeconds(Params.GetCorpseLifeTime());

            Destroy(this.gameObject);
        }
    }
    public void Stay()
    {
        SetState(States.IDLE);
        m_navMeshAgent.isStopped = true;
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
