//player collider �浹 ���� ��
//����Type+�浹 ����+��� ���� ���� ���� 
//bhaptics(attacked) or sleeve(defense) signal
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    //void Start()
    //{
       
    //}
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)    //collisor ���� �ȿ� ���� ��, ����ü�� Collider component �ʼ�
    {

        var AttackType = ChooseAttackType(other);
        

        //Vector2 direction = other.
        //    GetContact(0).normal;
        //If(direction.x == 1) print(��right��);
        //If(direction.x == -1) print(��left��);
        //If(direction.y == 1) print(��up��);
        //If(direction.y == -1) print(��down��);
    }
    private string ChooseAttackType(Collider other)
    {
        if (other.gameObject.CompareTag("FireBall"))    //�� �����̶� �浹 ��
        {
            return "FireBall";
        }
        else if (other.gameObject.CompareTag("IceBall"))    //���� �����̶� �浹 ��
        {
            return "IceBall";
        }
        else
        {
            return "None";
        }
    }
}
