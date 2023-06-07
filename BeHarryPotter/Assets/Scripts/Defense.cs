//Defense collider �浹 ���� ��(��� ����)
//AttackType ���� 
//arm sleeve signal
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;

public class Defense : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)    //collisor ���� �ȿ� ���� ��, ����ü�� Collider component �ʼ�
    {
        var AttackType = ChooseAttackType(other);    //�浹 ��ü�� �� ���� or ���� ����
        var df = new ArmSleeveHandler();

    }
    private string ChooseAttackType(Collision other)
    {
        if (other.collider.gameObject.CompareTag("FireBall")) { return "FireBall"; }
        else if (other.collider.gameObject.CompareTag("IceBall")) { return "IceBall"; }
        else { return "None"; }
    }
}
