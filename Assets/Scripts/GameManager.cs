using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    private int _currentScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Instance of ${nameof(Instance)} has an instance already exists");
        }

        Instance = this;
    }

    public void Score() => _currentScore++;
}
