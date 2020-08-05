namespace TransformMovement
{
    using UnityEngine;
    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        [SerializeField] private float _horizontalMin;
        [SerializeField] private float _horizontalMax;
        [SerializeField] private float _verticalMin;
        [SerializeField] private float _verticalMax;
        
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal == 0 && vertical == 0)
                return;
            
            TryMovement(horizontal,vertical);
        }

        private void TryMovement(float hAxis, float vAxis)
        {
            var position = transform.position;
            
            if (vAxis > 0 && position.y >= _verticalMax) vAxis = 0;
            else if (vAxis < 0 && position.y <= _verticalMin) vAxis = 0;
            
            if (hAxis > 0 && position.x >= _horizontalMax) hAxis = 0;
            else if (hAxis < 0 && position.x <= _horizontalMin) hAxis = 0;
            transform.Translate(new Vector3(hAxis,vAxis,0)*Time.deltaTime*_speed);
        }
    }
}