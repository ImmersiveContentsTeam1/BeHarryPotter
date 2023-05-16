using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackDefense;

public class MagicHandler : MonoBehaviour
{
    //�����ν�+��� �� �� ��ġ �� ����
    //vlaues : Wit���� ���� �ν� ���� ��, intent �� �޾ƿ�
    public void MagicCheck(string[] values) 
    {
        //���� : Incendio
        if (values[0] == "flame") { Flame(); };
        //���� : Wingardium Leviosa
        if (values[0] == "levitate") { Levitate(); };
        //���� : Repello
        if (values[0] == "defense") { Defense(); };
        //���� : Immobulus
        if (values[0] == "freeze") { Freeze(); };
    }

    void Flame(){
        Debug.Log("This is flame");

        var at = new AttackedHandler();
        at.Attacked_Bhaptics(AttackedHandler.attackedDirection.Left);
        }
    void Levitate() {
        Debug.Log("This is levitate");
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
