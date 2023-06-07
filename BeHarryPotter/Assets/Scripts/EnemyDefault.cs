using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDefault: LivingEntity
{
    private Animator animator;
    private LayerMask whatIsTarget; //������� ���̾�
    private Transform _transform;
    private Transform playerTransform;

    private LivingEntity target;//�������

    //component
    NavMeshAgent nav; //��� ��� AI ������Ʈ
    Rigidbody rigid;
    CapsuleCollider capsuleCollider;

    private bool isDead = false;

    public enum CurrentState { idle, walk, attack, dead, block};
    public CurrentState curState = CurrentState.idle;

    public float chaseDistance;
    public float attackDistance;
    public float shieldDistance;

    /*public ParticleSystem hitEffect; //�ǰ� ����Ʈ
    public AudioClip deathSound;//��� ����
    public AudioClip hitSound; //�ǰ� ����
    */

    //������
    public GameObject firePoint; //�����̻����� �߻�� ��ġ
    public GameObject magicMissilePrefab; //����� �����̻��� �Ҵ�
    public GameObject magicMissile; //Instantiate()�޼���� �����ϴ� �����̻����� ��� ���ӿ�����Ʈ

    //private AudioSource enemyAudioPlayer; //����� �ҽ� ������Ʈ

    public float damage = 30f; //���ݷ�
    public float attackDelay = 2.5f; //���� ������
    private float lastAttackTime; //������ ���� ����

    private bool canMove;
    private bool canAttack;

    private void Awake()
    {
        //���� ������Ʈ���� ����� ������Ʈ ��������
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void Setup(float newHealth)
    {
        //ü�� ����
        startingHealth = newHealth;
        health = newHealth;
    }

    private void Start()
    {
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        
        StartCoroutine(this.CheckState());
        
    }


    //������ ����� ��ġ�� �ֱ������� ã�� ��� ����, ����� ������ �����Ѵ�.
    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }

    public void Chase(Vector3 targetPosition)
    {
        animator.SetBool("CanMove", true);
        nav.SetDestination(targetPosition);

        animator.SetBool("CanAttack", false);
    }

    public IEnumerator CheckState()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(0.2f);
            float distance = Vector3.Distance(playerTransform.position, _transform.position);

            if (distance <= attackDistance)
            {
                curState = CurrentState.attack;
                StartCoroutine(Attack());
            }
            else if (distance <= chaseDistance)
            {
                curState = CurrentState.walk;
                Chase(playerTransform.position);
            }
            else if (startingHealth == 0)
            {
                animator.SetTrigger("Die");
                nav.isStopped = true;
                isDead = true;
            }
            /*
            else
            {
                curState = CurrentState.idle;
                animator.SetBool("IsWalk", true);
                animator.SetBool("IsAttack", false);
            }
            */
        }
    }

    IEnumerator Attack()
    {
        float distance = Vector3.Distance(playerTransform.position, _transform.position);

        nav.ResetPath();
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("CanMove", false);

        if (distance <= shieldDistance)
        {
            //animator.SetBool("IsWalk", false);
            animator.SetBool("CanAttack", false);
        }
        else if (distance > shieldDistance)
        {
            //animator.SetBool("IsWalk", false);
            animator.SetBool("CanAttack", true);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health = health - 10f;
            StartCoroutine(OnDamaged());
        }

        else if (other.tag == "Bullet")
        {
            health = health - 10f;
            StartCoroutine(OnDamaged());
        }
    }

    IEnumerator OnDamaged()
    {
        if (health > 0)
        {
            yield return null;
        }
        else
        {
            animator.SetTrigger("Die");
        }
    }

    //����Ƽ �ִϸ��̼� �̺�Ʈ�� �����̸� ������ �ֵθ� �� �޼��� ����
    public void ShamanFire()
    {
        magicMissile = Instantiate(magicMissilePrefab, firePoint.transform.position, firePoint.transform.rotation); //Instatiate()�� ���� �̻��� �������� ���� �����Ѵ�.
    }

    /*�̻��Ͽ��� ������ ó���ϱ�
    
    //����Ƽ �ִϸ��̼� �̺�Ʈ�� �ֵθ� �� ������ �����Ű��
    public void OnDamageEvent()
    {
        //������ LivingEntity Ÿ�� ��������
        LivingEntity attackTarget = targetEntity.GetComponent<LivingEntity>();

        //���� ó��
        attackTarget.OnDamage(damage);
    }
    */


    //�������� �Ծ��� �� ������ ó��
    

    //��� ó��
    public override void Die()
    {
        //LivingEntity�� DIe()�� �����Ͽ� �⺻ ��� ó�� ����
        base.Die();

        //�ٸ� AI�� �������� �ʵ��� �ڽ��� ��� �ݶ��̴��� ��Ȱ��ȭ
        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        //AI������ �����ϰ� �׺�޽� ������Ʈ�� ��Ȱ��ȭ
        nav.isStopped = true;
        nav.enabled = false;

        //��� �ִϸ��̼� ���
        animator.SetTrigger("Die");
        /*//��� ȿ���� ���
        enemyAudioPlayer.PlayOnShot(deathSound);
        */

    }
}