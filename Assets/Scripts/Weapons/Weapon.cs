using UnityEngine;

public class Weapon : MonoBehaviour
{
   [SerializeField] protected Transform _shootPoint;
   [SerializeField] protected Bullet _bullet;
   [SerializeField] protected ParticleSystem _shootParticle;
   [field: SerializeField] public float RateFire { get; private set; }

   public  virtual void Shoot(Vector3 moveDirection)
   {
      CreateBullet(moveDirection);
   }

   protected void CreateBullet(Vector3 moveDirection)
   {
      Bullet newBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
      newBullet.Init(moveDirection);
   }
   
}
