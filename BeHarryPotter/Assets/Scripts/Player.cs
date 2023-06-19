//player collider �浹 ���� ��(��� ����)
//Bhaptics signal + ArmSleeve signal(Sample User Polling_readwrite script)
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using HapticsHandler;
using UnityEngine.Timeline;



public class Player : MonoBehaviour
{
    public AudioClip[] soundEffects;  // �ٸ� ȿ������ ���� �迭

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // �÷��̾��� �ൿ�� ���� �ٸ� ȿ������ ����ϴ� �Լ�
    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            audioSource.clip = soundEffects[index];
            audioSource.Play();
        }
    }


    private void OnCollisionEnter(Collision other)    //collisor ���� �ȿ� ���� ��, ����ü�� Collider component �ʼ�
    {
        SignalToBhaptics(ChooseAttackDirection(other)); //Bhaptics signal
    }

    private void SignalToBhaptics(string AttackDirection)
    {
        var at = new BHapticsHandler();

        if (AttackDirection == "right")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Right);
        }
        else if (AttackDirection == "left")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Left);
        }
        else if (AttackDirection == "front")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Front);
        }
        else if (AttackDirection == "back")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Back);
        }
    }

    private string ChooseAttackDirection(Collision other)
    {
        Vector3 direction = other.GetContact(0).normal;

        Debug.Log(direction);

        if (0.5<=direction.x || direction.x <= 1.5) { return  "left"; }
        else if (-1.5 <= direction.x || direction.x <= -0.5) { return "right"; }
        else if (direction.z == 1) { return "back"; }
        else if (direction.z == -1) { return "front"; }
        else { return "None"; };
    }
}
