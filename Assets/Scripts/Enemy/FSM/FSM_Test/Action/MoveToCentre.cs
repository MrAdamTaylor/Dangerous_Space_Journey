using UnityEngine;

namespace Enemy.FSM.FSM_Test.Action
{
    class MoveToCentre : SomeAction
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float speed;

        private float zPosition;
        private Vector3 destination;
        private Vector3 direction;

        private const float epsilonOfDestination = 2f;

        private void Start()
        {
            //_rigidbody = GetComponent<Rigidbody>();
            zPosition = transform.position.z;
            destination = new Vector3(0, 0, zPosition);
        }

        public override void Execute()
        {
            //Debug.Log("Выполнение движения");
            if(CalculateDistance() > epsilonOfDestination)
            {
                direction = (destination - transform.position).normalized;
                _rigidbody.MovePosition(_rigidbody.position + direction * speed * Time.deltaTime);
            }
            
        }

        public override void ExecuteCoroutine()
        {
        }

        private float CalculateDistance()
        {
            float distance = Vector3.Distance(destination, transform.position);
            return distance;
        }
    }
}