using UnityEngine;

public interface IDamageable
{
    void TakeHit(float damage, Vector3 hotPoint, Vector3 hitDirection);
    void TakeDamage(float damage);

}