//�����ν�  ��ġ �� ���� activate
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;

public class MagicHandler : MonoBehaviour
{
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
        Debug.Log("This is flame");

        var at = new BHapticsHandler();
        at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Left);
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
