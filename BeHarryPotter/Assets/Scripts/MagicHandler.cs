//�����ν�  ��ġ �� ���� activate
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;
using UnityEditor;

public class MagicHandler : MonoBehaviour
{
    public GameObject icePrefab;
    public GameObject defensePrefab;
    public Transform magicPos;

    AudioSource audioSource;
    public AudioClip defensespell;
    public AudioClip attackspell;

    //private void Start()
    //{
    //    defensespell = GetComponent<AudioSource>();
    //}

    //private float speed = 5f;

    public void MagicCheck(string[] values)    //values : Wit���� ���� �ν� ���� ��, intent �� �޾ƿ�
    {
        //���� : Incendio
        if (values[0] == "flame") { Flame(); };
        //���� : Protego
        if (values[0] == "defense") { Defense(); };
    }
    
    void Flame()
    {
        OVRInput.SetControllerVibration(1f, 2f, OVRInput.Controller.RHand);
        GameObject magic = Instantiate(icePrefab, magicPos.transform.position, magicPos.transform.rotation);
        Debug.Log("���� ����");
        audioSource.clip = attackspell;
        audioSource.Play();
    }
    void Defense()
    {
        OVRInput.SetControllerVibration(1f, 2f, OVRInput.Controller.RHand);
        GameObject magic = Instantiate(defensePrefab, new Vector3(0.74f, 8f, 7.7f), Quaternion.Euler(new Vector3(90,0,0)));
        Debug.Log("�� ����");
        audioSource.clip= defensespell; 
        audioSource.Play(); 
        //defensespell.Play();
        Destroy(magic, 5f);
    }
}
