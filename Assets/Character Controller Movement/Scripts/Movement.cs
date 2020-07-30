using UnityEngine;

namespace Character_Controller_Movement.Scripts
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 5f;

        [Header("Inputs Values")]
        [SerializeField] private float horizontalInput;
        [SerializeField] private float verticalInput;

        [Header("Direction")]
        [SerializeField] private Vector3 direction;
        
        // Start is called before the first frame update
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            ReceiveInput();
            CalculateDirection();
            
            if(direction.magnitude > 0.1f)
                Move();
        }

        private void ReceiveInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        private void CalculateDirection()
        {
            direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        }

        private void Move()
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
