using UnityEngine;
using UnityEngine.UI;

namespace player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        [SerializeField] private Image _canvasHealth;
        [SerializeField] private Animator _animator;
        [SerializeField] private Gun _gun;

        private Player _model;
        private const float SPEED_ROTATION = 1f;
        private IClosestTargetFinder _targetFinder;

        public void Init(Player model, IClosestTargetFinder targetFinder, Vector3 position)
        {
            _targetFinder = targetFinder;
            _model = model;
            _model.HealthChanged += SetHealth;
            transform.position = position;
        }

        public void TryFire() 
            => _gun.TryShoot();

        public void SetRotation(Vector3 rotateVector)
        {
            var direction = Vector3.RotateTowards(transform.forward, rotateVector, SPEED_ROTATION, 0);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public void LookAtClosestEnemy()
        {
            Vector3 targetPosition = _targetFinder.GetClosestPosition(transform.position);
            var rotateVector = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z);
            SetRotation(rotateVector);
        }

        public void SetHealth(float value)
        {
            if (value > 1 && value < 0)
                Debug.LogError("Invalid UI health value");

            _canvasHealth.fillAmount = value;
        }

        public void SetMoveVector(Vector3 moveVector)
        {
            Vector3 localMove = transform.InverseTransformDirection(moveVector);
            _animator.SetFloat("Forward", localMove.z, 0.1f, Time.deltaTime);
            _animator.SetFloat("Turn", localMove.x, 0.1f, Time.deltaTime);
        }

        public void SetMass(float value) => _rigidbody.mass = value;

        public void Move() => _animator.SetBool("move", true);

        public void Stop() => _animator.SetBool("move", false);

        public void Aim() => _animator.SetBool("aiming", true);

        public void StopAim() => _animator.SetBool("aiming", false);

        public void SetBrave() => _animator.SetTrigger("brave");

        public void SetBreak() => _animator.SetTrigger("break");
    }
}