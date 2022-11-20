using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private CapsuleCollider coll;

    private GameObject target;
    private GameObject player;

    public GameObject fireballPrefab;
    public GameObject fireballSpawnPoint;
    float motionSmoothTime = .01f;
    float rotateVelocity;
    public float rotateSpeedMovement = 0.1f;

    public bool die = false;
    public bool attacking = false;

    private float abilityCd;
    private bool abilityIsCd;

    private Score score;

    private bool hasSkill;

    public GameObject potionPrefab;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        coll = GetComponent<CapsuleCollider>();
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>();
        agent.speed = 2.5f;
        abilityCd = 2f;
        abilityIsCd = false;
        DifficultyControl();
    }

    // Update is called once per frame
    void Update()
    {
        if(!target.GetComponent<Movement>().die) {
            Movement();
            if(hasSkill)
            {
                Fireball();
            }
        } else {
            Stop();
        }
    }

    void Movement() 
    {
        if (!die && !attacking)
        {
            agent.SetDestination(target.transform.position);

            Quaternion rotationToLookAt = Quaternion.LookRotation(target.transform.position - transform.position);
            float rotationY = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                rotationToLookAt.eulerAngles.y,
                ref rotateVelocity,
                rotateSpeedMovement * Time.deltaTime
            );

            transform.eulerAngles = new Vector3(0, rotationY, 0);

            float speed = agent.velocity.magnitude / agent.speed;
            anim.SetFloat("Move", speed, motionSmoothTime, Time.deltaTime);
        }
    }

    void Fireball()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance <= 7 && !die && !attacking && !abilityIsCd){
            abilityIsCd = true;
            attacking = true;
            Stop();
            StartCoroutine(SetAbilityCd());
            anim.SetTrigger("Fireball");
        }
    }

    IEnumerator SetAbilityCd()
    {
        yield return new WaitForSeconds(abilityCd);
        abilityIsCd = false;
    }

    void Cast() {
        attacking = false;
        GameObject skill = Instantiate(fireballPrefab, fireballSpawnPoint.transform.position, fireballSpawnPoint.transform.rotation);
        skill.GetComponent<FireballSkill>().type = "Bot";
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && !die && !attacking)
        {
            attacking = true;
            anim.SetTrigger("Attack");
            Stop();
        }
    }

    public void Die()
    {
        Stop();
        die = true;
        score.Increment();
        coll.isTrigger = true;
        anim.SetTrigger("Die");
        Drop();
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }

    public void OnAttack()
    {
        target.GetComponent<PlayerStats>().TakeDamage(50);
        attacking = false;
    }

    public void Stop()
    {
        agent.SetDestination(transform.position);
        agent.ResetPath();
    }

    private void Drop()
    {
        if(Random.Range(1, 10) == 1) {
            Instantiate(potionPrefab, new Vector3(transform.position.x, 2, transform.position.z), transform.rotation);
        }
    }

    private void DifficultyControl()
    {
        if (Random.Range(1, 5) == 1) hasSkill = true;
        else hasSkill = false;

        if(gameController.difficulty ==  2) {

            agent.speed = 2.7f;

        } else if(gameController.difficulty == 3) {

            agent.speed = 2.9f;
            if (Random.Range(1, 4) == 1) hasSkill = true;
            else hasSkill = false;

        } else if(gameController.difficulty == 4) {

            agent.speed = 3.2f;
            if (Random.Range(1, 3) == 1) hasSkill = true;
            else hasSkill = false;

        } else if(gameController.difficulty == 5) {

            agent.speed = 3.5f;
            if (Random.Range(1, 2) == 1) hasSkill = true;
            else hasSkill = false;

        }
    }
}
