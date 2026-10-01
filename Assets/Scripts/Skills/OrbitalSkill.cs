using UnityEngine;

public class OrbitalSkill : MonoBehaviour
{
    [SerializeField] private OrbitalProjectile projectilePrefab;
    [SerializeField] private int projectileCount = 2;
    [SerializeField] private float orbitRadius = 2f;
    [SerializeField] private float rotationSpeed = 180f;

    private void Start()
    {
        CreateProjectiles();
    }

    private void Update()
    {
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime);
    }

    private void CreateProjectiles()
    {
        float angleStep = 360f / projectileCount;

        for (int i = 0; i < projectileCount; i++)
        {
            float angle = angleStep * i;
            float radians = angle * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Cos(radians),
                0f,
                Mathf.Sin(radians)
            ) * orbitRadius;

            OrbitalProjectile projectile = Instantiate(
                projectilePrefab,
                transform.position + offset,
                Quaternion.identity,
                transform);
        }
    }
}
