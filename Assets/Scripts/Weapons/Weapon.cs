using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Weapon : Item
{
   [SerializeField] protected Transform _shootPoint;
   [SerializeField] protected Bullet _bullet;
   [SerializeField] private float _rateFire;
   private Rigidbody _rigidbody;
   public UnityEvent Shooting;

   private float _timeAfterLastShoot;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   protected void Update()
   {
      _timeAfterLastShoot += Time.deltaTime;
   }

   public override void UseItem(Vector3 moveDirection)
   {
      if (_timeAfterLastShoot <= _rateFire) return;
      
      _timeAfterLastShoot = 0;
      Shoot(moveDirection);
   }

   public override void SelectItem()
   {
      if (_rigidbody == null)
         _rigidbody = GetComponent<Rigidbody>();
      enabled = true;
      _rigidbody.isKinematic = true;
   }

   public override void DropItem()
   {
      if (_rigidbody == null)
         _rigidbody = GetComponent<Rigidbody>();
      _rigidbody.isKinematic = false;
   }

   private void Shoot(Vector3 moveDirection)
   {
      Shooting?.Invoke();
      ShootLogic(moveDirection);
   }

   protected virtual void ShootLogic(Vector3 moveDirection)
   {
      CreateBullet(moveDirection);
   }

   protected void CreateBullet(Vector3 moveDirection)
   {
      Bullet newBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
      newBullet.Init(moveDirection);
   }

 
}
