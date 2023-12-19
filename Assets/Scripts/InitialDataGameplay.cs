using UnityEngine;

[CreateAssetMenu(
    fileName = "Initial Data Gameplay",
    menuName = "Quiz Game/Initial Data Gameplay")]
public class InitialDataGameplay : ScriptableObject
{
    public QuizLevelPack levelPack = null;
    public int levelIndex = 0;

    [SerializeField]
    private bool _whenLose = false;
    
    public bool whenLose
    {
        get => _whenLose;
        set => _whenLose = value;
    }
}
