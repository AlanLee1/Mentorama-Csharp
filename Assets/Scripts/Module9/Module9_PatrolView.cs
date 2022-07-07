using TMPro;
using UnityEngine;

public class Module9_PatrolView : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Module9_Patrol PatrolComponent;

    void Start()
    {
        PatrolComponent.OnStartedMoving += StartedMovingEventHandler;
        PatrolComponent.OnStoppedMoving += StoppedMovingEventHandler;
    }

    private void StartedMovingEventHandler(int value)
    {
        switch (value)
        {
            case 1:

                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }

        Text.text = $"{value}";
    }
    private void StoppedMovingEventHandler()
    {
        Text.text = "Idle";
    }

}
