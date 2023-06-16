/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

namespace HapticsHandler
{
    public class SampleUserPolling_ReadWrite : MonoBehaviour
    {
        public SerialController serialController;

        void Start()
        {
            serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        }

        public void firesignal()
        {
            //Debug.Log("������ fire������?");
            serialController.SendSerialMessage("A");

            string message = serialController.ReadSerialMessage();

            if (message == null)
                return;

            // Check if the message is plain data or a connect/disconnect event.
            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
                Debug.Log("Connection established");
            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
                Debug.Log("Connection attempt failed or disconnection detected");
            else
                Debug.Log("Message arrived: " + message);
        }
        public void icesignal()
        {
            //Debug.Log("������ ice������?");
            serialController.SendSerialMessage("Z");

            string message = serialController.ReadSerialMessage();

            if (message == null)
                return;

            // Check if the message is plain data or a connect/disconnect event.
            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
                Debug.Log("Connection established");
            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
                Debug.Log("Connection attempt failed or disconnection detected");
            else
                Debug.Log("Message arrived: " + message);
        }


        //�� object script(Defense)
        private void OnCollisionEnter(Collision other)    //�� object : collider, �� script������ �� 
        {
            var AttackType = ChooseAttackType(other);

            if (AttackType == "FireBall")
            {
                //Debug.Log("���̾ ���");
                firesignal();

            }
            else if (AttackType == "IceBall")
            {
                //Debug.Log("���̽��� ���");
                icesignal();
            }
        }
        private string ChooseAttackType(Collision other)
        {
            if (other.collider.gameObject.CompareTag("FireBall")) { return "FireBall"; }
            else if (other.collider.gameObject.CompareTag("IceBall")) { return "IceBall"; }
            else { return "None"; }
        }


        private void Update()
        {

            OVRInput.Update();

            //if (OVRInput.Get(OVRInput.RawButton.B))    //2. A button ������ 
            //{
            //    firesignal();
            //    Debug.Log("dsbdusfgsgbfsgbfubsuf s");
            //}
            //else if (OVRInput.GetUp(OVRInput.Button.One))    //2. A button ����
            //{
            //    Debug.Log("button, end");
            //    //wit.Deactivate();
            //}
            if (OVRInput.Get(OVRInput.RawButton.A))    //2. A button ������ 
            {
                icesignal();
            }
        }

    }
}