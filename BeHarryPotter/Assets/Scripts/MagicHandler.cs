//�����ν�  ��ġ �� ���� activate
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;

public class MagicHandler : Magic
{
    public GameObject magicPrefab;

    public void MagicCheck(string[] values)    //vlaues : Wit���� ���� �ν� ���� ��, intent �� �޾ƿ�
    {
        //���� : Incendio
        if (values[0] == "flame") { Flame(); };
        //���� : Protego
        if (values[0] == "defense") { Defense(); };
        //���� : Immobulus
        if (values[0] == "freeze") { Freeze(); };
    }

    void Flame(){
 //       GameObject magic = Instantiate(magicPrefab, magicPos.position, magicPos.rotation);
        Debug.Log("This is flame");
    }
    void Defense()
    {
        Debug.Log("This is defense");
    }
    void Freeze()
    {
        Debug.Log("This is freeze");
    }
}
