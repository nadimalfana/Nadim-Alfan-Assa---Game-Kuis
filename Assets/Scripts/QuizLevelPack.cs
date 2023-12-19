using UnityEngine;

[CreateAssetMenu(
    fileName = "New Level Pack",
    menuName = "Quiz Game/Quiz Level Pack"
)]
public class QuizLevelPack : ScriptableObject
{
    [SerializeField]
    private QuizQuestionLevel[] _levelContent = new QuizQuestionLevel[0];

    public int LevelCount => _levelContent.Length;

    public QuizQuestionLevel GrabLevelIndex(int index)
    {
        return _levelContent[index];
    }
}
