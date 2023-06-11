//player collider �浹 ���� ��(��� ����)
//AttackDirection ���� 
//bhaptics(attacked) signal
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using HapticsHandler;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)    //collisor ���� �ȿ� ���� ��, ����ü�� Collider component �ʼ�
    {
        var AttackDirection = ChooseAttackDirection(other);    //�浹 ����
        var at = new BHapticsHandler();

        if (AttackDirection == "right")
        {
            Debug.Log("�������� �ƾ��մϴ�!");
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Right);
        }
        else if(AttackDirection == "left")
        {
            Debug.Log("������ �ƾ��մϴ�!");
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Left);
        }
        else if (AttackDirection == "front")
        {
            Debug.Log("���� �ƾ��մϴ�!");
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Front);
        }
        else if (AttackDirection == "back")
        {
            Debug.Log("�ڰ� �ƾ��մϴ�!");
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Back);
        }
    }

    private string ChooseAttackDirection(Collision other)
    {
        Vector3 direction = other.GetContact(0).normal;

        if (direction.x == 1) { return  "right"; }
        else if (direction.x == -1) { return "left"; }
        else if (direction.z == 1) { return "front"; }
        else if (direction.z == -1) { return "back"; }
        else { return "None"; };
    }
}
