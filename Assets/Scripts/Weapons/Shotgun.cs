using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField,Range(0f,100f)] private int _numberBulletsPerShot = 1;
    [SerializeField,Range(0f,100f)] private float _spreadFactor =1f;
    public override void Shoot(Vector3 moveDirection)
    {
        Debug.Log("Shoot");
        for (int i = 0; i < _numberBulletsPerShot; i++)
        {
            Vector3 newMoveDirection = new Vector3(Random.Range(-_spreadFactor, _spreadFactor),
                Random.Range(-_spreadFactor, _spreadFactor), Random.Range(-_spreadFactor, _spreadFactor));
            
            var direction = Quaternion.Euler(newMoveDirection) * moveDirection;
            CreateBullet(direction);
            Debug.Log(direction);
            Debug.Log(moveDirection);

        }
    }
}
