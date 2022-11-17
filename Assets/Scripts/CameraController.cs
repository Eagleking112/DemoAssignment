using UnityEngine;

namespace Camera_Ankush
{
    public class CameraController : MonoBehaviour
    {
        public Player_Ankush.PlayerController playerController;
        public Transform orientation;
        public Transform player;
        public Transform playerObj;
        public float rotationSpeed;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
                playerController.Move(orientation.forward * verticalInput + orientation.right * horizontalInput);
                playerController.PlayAnimation(1);
            }
            else {
                playerController.PlayAnimation(0);
            }
        }
    }
}