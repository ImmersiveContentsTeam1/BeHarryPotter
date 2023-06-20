using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour//, IDamageable ���� ����
{
    public float startingHealth = 100f; //���� ü��
    public float health { get; protected set; } //���� ü��
    public bool dead { get; protected set; } //��� ����

    public event Action onDeath; //��� �� �ߵ��� �̺�Ʈ

    //����ü�� Ȱ��ȭ�� �� ���¸� ����
    protected virtual void OnEnable()
    {
        //������� ���� ���·� ����
        dead = false;
        //ü���� ���� ü������ �ʱ�ȭ
        health = startingHealth;
    }


    //���ظ� �޴� ���
    public virtual void OnDamage(float damage)
    {
        //��������ŭ ü�� ����
        health -= damage; // health = health - damage;

        //ü���� 0 ���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if (onDeath != null)
        {
            onDeath();
        }

        dead = true;
    }

}