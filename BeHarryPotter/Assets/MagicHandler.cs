using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Flame(){ }
    void Levitate() { }
}
