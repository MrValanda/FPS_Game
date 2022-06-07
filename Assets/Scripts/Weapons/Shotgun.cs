using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField, Range(0f, 100f)] private int _numberBulletsPerShot = 1;
    [SerializeField, Range(0f, 100f)] private float _spreadFactor = 1f;

    protected override void ShootLogic(Vector3 moveDirection)
    {
        for (int i = 0; i < _numberBulletsPerShot; i++)
        {
            Vector3 newMoveDirection = new Vector3(Random.Range(-_spreadFactor, _spreadFactor),
                Random.Range(-_spreadFactor, _spreadFactor), Random.Range(-_spreadFactor, _spreadFactor));
            
            var direction = Quaternion.Euler(newMoveDirection) * moveDirection;
            CreateBullet(direction);
        }
    }
}
