using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    private LineRenderer rendo;
    // Start is called before the first frame update
    void Start()
    {
        rendo=gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            DoPewPew(transform.position, transform.forward, 5f);
            rendo.enabled = true;
        }
        else
        {
            rendo.enabled = false;
        }
    }

    void DoPewPew(Vector3 targetPos, Vector3 direction, float length)
    {
        Ray ray=new Ray(targetPos, direction);
        Vector3 endPos = targetPos + (direction * length);

        //ray�� �ٸ� ��ü�� �ε����� ������ endpoint, ���X
        if(Physics.Raycast(ray, out RaycastHit rayHit, length))
        {
            endPos = rayHit.point;
            //ray�� �ε��� object name
            Debug.Log(rayHit.collider.gameObject.name);
        }

        rendo.SetPosition(0, targetPos);
        rendo.SetPosition(1, endPos);
    }
}
