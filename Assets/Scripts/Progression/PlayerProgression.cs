using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField] private int startingLevel = 1;
    [SerializeField] private float startingExperienceToNextLevel = 10f;
    [SerializeField] private float experienceMultiplier = 1.2f;

    private int currentLevel;
    private float currentExperience;
    private float experienceToNextLevel;

    private void Awake()
    {
        currentLevel = startingLevel;
        experienceToNextLevel = startingExperienceToNextLevel;
    }

    public void AddExperience(float amount)
    {
        currentExperience += amount;

        Debug.Log($"XP: {currentExperience}/{experienceToNextLevel}");

        while (currentExperience >= experienceToNextLevel)
        {
            currentExperience -= experienceToNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        experienceToNextLevel *= experienceMultiplier;

        Debug.Log($"Level Up! Current level: {currentLevel}");
    }
}
