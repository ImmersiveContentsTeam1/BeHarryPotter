using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defense : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)  
    {
        if (other.collider.gameObject.CompareTag("IceBall"))   //�� ���� ��� ���� �� 
        {
            //��� ���� �Ҹ�
        }
    }
}
