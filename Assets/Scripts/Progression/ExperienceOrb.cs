using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    [SerializeField] private float experienceValue = 1f;

    public void SetValue(float value)
    {
        experienceValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerProgression progression = other.GetComponent<PlayerProgression>();

        if (progression == null) return;

        progression.AddExperience(experienceValue);

        Destroy(gameObject);
    }
}
