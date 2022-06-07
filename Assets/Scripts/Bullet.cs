using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
   [SerializeField,Range(0f,100f)] private float _speed;
   [SerializeField,Range(0,100)] private int _damage;
   [SerializeField] private float _bulletLifeTime=10f;
   
   private Rigidbody _rigidbody;
   private Vector3 _moveDirection;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _rigidbody.velocity = _moveDirection * _speed;
      Invoke(nameof(DestroyBullet), _bulletLifeTime);
   }

   private void FixedUpdate()
   {
      transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
   }

   public void Init(Vector3 moveDirection)
   {
      _moveDirection = moveDirection.normalized;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Bullet _) || other.TryGetComponent(out Weapon _)) return;
      
      if (other.TryGetComponent(out IDamageable damageable))
      {
         damageable.ApplyDamage(_damage);
      }

      DestroyBullet();
   }
   
   private void DestroyBullet()
   {
      Destroy(gameObject);
   }
}