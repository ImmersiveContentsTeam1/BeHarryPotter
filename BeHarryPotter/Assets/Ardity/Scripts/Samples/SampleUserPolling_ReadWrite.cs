//player collider �浹 ���� ��(��� ����)
//Bhaptics signal + ArmSleeve signal(Sample User Polling_readwrite script)

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

        public void leftsignal()
        {
            Debug.Log("��Ƽ�� Left ");
            serialController.SendSerialMessage("A");

            string message = serialController.ReadSerialMessage();

            if (message == null)
                return;

            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
                Debug.Log("Connection established");
            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
                Debug.Log("Connection attempt failed or disconnection detected");
            else
                Debug.Log("Message arrived: " + message);
        }
        public void rightsignal()
        {
            Debug.Log("��Ƽ�� Right");
            serialController.SendSerialMessage("Z");

            string message = serialController.ReadSerialMessage();

            if (message == null)
                return;

            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
                Debug.Log("Connection established");
            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
                Debug.Log("Connection attempt failed or disconnection detected");
            else
                Debug.Log("Message arrived: " + message);
        }
        public void frontsignal()
        {
            Debug.Log("��Ƽ�� Front");
            serialController.SendSerialMessage("F");

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

        private void OnTriggerEnter(Collider other)
        {
            SignalToSleeve(ChooseAttackDirection(other.transform.name));
        }


        private void SignalToSleeve(string AttackDirection)
        {
            if (AttackDirection == "front")
            {
                frontsignal();
            }
            else if(AttackDirection == "left")
            {
                leftsignal();
            }
            else if (AttackDirection == "right")
            {
                rightsignal();
            }

        }

        private string ChooseAttackDirection(string enemyName)
        {
            if (enemyName == "EnemyFront") { return "front"; }
            else if (enemyName == "EnemyLeft") { return "left"; }
            else if (enemyName == "EnemyRight") { return "right"; }
            else { return "None"; }
        }
    }
}