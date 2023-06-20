using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour//, IDamageable ���� ����
{
    public float startingHealth = 100f; //���� ü��
    public float health { get; protected set; } //���� ü��

    //����ü�� Ȱ��ȭ�� �� ���¸� ����
    protected virtual void OnEnable()
    {
        //ü���� ���� ü������ �ʱ�ȭ
        health = startingHealth;
    }


}