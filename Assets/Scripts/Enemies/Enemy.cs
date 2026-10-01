using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float maxHealth = 10f;

    private Transform target;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Initialize(Transform target)
    {
        this.target = target;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
