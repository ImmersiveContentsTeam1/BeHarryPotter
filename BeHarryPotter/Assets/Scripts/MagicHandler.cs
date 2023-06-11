//�����ν�  ��ġ �� ���� activate
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;
using UnityEditor;

public class MagicHandler : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject icePrefab;
    public GameObject defensePrefab;
    public Transform magicPos;

    private float speed = 5f;

    public void MagicCheck(string[] values)    //values : Wit���� ���� �ν� ���� ��, intent �� �޾ƿ�
    {
        //���� : Incendio
        if (values[0] == "flame") { Flame(); };
        //���� : Protego
        if (values[0] == "defense") { Defense(); };
        //���� : Immobulus
        if (values[0] == "freeze") { Freeze(); };
    }
    
    void Flame()
    {
        GameObject magic = Instantiate(firePrefab, magicPos.transform.position, magicPos.transform.rotation);
        Debug.Log("This is flame");
    }
    void Defense()
    {
        GameObject magic = Instantiate(defensePrefab, magicPos.transform.position, magicPos.transform.rotation);
        Debug.Log("This is defense");
        Destroy(magic, 3f);
    }
    void Freeze()
    {
        GameObject magic = Instantiate(icePrefab, magicPos.transform.position, magicPos.transform.rotation);
        Debug.Log("This is freeze");
    }
}
