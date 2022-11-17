using UnityEngine;

namespace Player_Ankush
{
    [RequireComponent(typeof(CharacterController),typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float playerSpeed = 1.5f;
        private float gravityValue = -9.81f;
        private Animator playerAnimator;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            playerAnimator = GetComponent<Animator>();
        }

        public void Move(Vector3 moveDirection)
        {
            controller.Move(moveDirection * Time.deltaTime * playerSpeed);
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        public void PlayAnimation(int value)
        {
            playerAnimator.SetFloat("Speed",value);
        }
    }
}