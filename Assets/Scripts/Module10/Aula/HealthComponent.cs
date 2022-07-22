using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    public HealthComponent(int max, int current)
    {
        MaxHealth = max;
        CurrentHealth = current;
    }

    public void Initialize(int max, int current)
    {
        MaxHealth = max;
        CurrentHealth = current;
    }

    void Update()
    {
        //Debug.Log($"{name}: {CurrentHealth}/{MaxHealth}");
    }
}
