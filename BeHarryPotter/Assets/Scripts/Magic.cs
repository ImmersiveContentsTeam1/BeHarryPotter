using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject target;
    private Rigidbody magicRigid;

    public float speed;
    public float rate = 3;

    public int damage = 10;

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.gameObject.CompareTag("Plane"))   //Plane�� �浹 ��
        {
            Debug.Log("Plane�̾�");
            Destroy(gameObject, 1f);
        }
        else if (other.collider.gameObject.CompareTag("Player"))   //Player�� �浹 ��
        {
            if (gameObject.tag == "FireBall") 
            {
                Destroy(gameObject);
            }
            else if(gameObject.tag == "PlayerMagic")
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        else if(other.collider.gameObject.CompareTag("Enemy"))   //Enemy�� �浹 ��
        {
            if (gameObject.tag == "FireBall") 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (gameObject.tag == "PlayerMagic")
            {
                Destroy(gameObject);
            }
        }
        else if (other.collider.gameObject.CompareTag("Shield"))   //Shield�� �浹 ��
        {
            if (gameObject.tag == "FireBall")
            {
                Destroy(gameObject);
            }
            else if (gameObject.tag == "PlayerMagic") 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    //magic�� "PlayerAttack"�̸� player�� �浹�ص� ������� �� ��, enemy�� �浹�ϸ� ���������. 
    //magic�� fireball�̸� ���� �浹ó�� �״�� 

    // Start is called before the first frame update
    void Start()
    {
        magicRigid = GetComponent<Rigidbody>();
        if (target == null)
        {

            GameObject tmp = GameObject.FindGameObjectWithTag("Player");
            target = tmp;
        }
    }
 

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            GameObject tmp = GameObject.FindGameObjectWithTag("Player");
            target = tmp;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    
}
