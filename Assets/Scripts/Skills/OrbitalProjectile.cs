using UnityEngine;
using UnityEngine.UIElements;

public class OrbitalProjectile : MonoBehaviour
{
    [SerializeField] private float damage = 3f;

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy == null) return;

        enemy.TakeDamage(damage);
    }
}
