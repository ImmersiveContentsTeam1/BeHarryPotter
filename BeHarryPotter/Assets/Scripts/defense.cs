using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defense : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip[] soundeffects;
    private void awake()
    {
        audiosource = GetComponent<AudioSource>();
    }


    public void playsoundeffect(int index)
    {
        if (index >= 0 && index < soundeffects.Length)
        {
            audiosource.clip = soundeffects[index];
            audiosource.Play();
        }
    }


    private void OnCollisionEnter(Collision other)  
    {
        if (other.collider.gameObject.CompareTag("IceBall"))   //�� ���� ��� ���� �� 
        {
            //��� ���� �Ҹ�
            playsoundeffect(1);
        }
        else if (other.collider.gameObject.CompareTag("Shield"))
        {
            playsoundeffect(0);
        }

    }
}
