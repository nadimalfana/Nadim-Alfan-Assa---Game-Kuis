using UnityEngine;

[CreateAssetMenu(
    fileName = "New Question",
    menuName = "Quiz Game/Quiz Quesstion Level"
)]

public class QuizQuestionLevel : ScriptableObject
{
        [System.Serializable]
        public struct Choice
        {
            public string answerChoice;
            public bool isCorrect;
        }
        public string questionText = string.Empty;
        public Sprite questionImage = null;
        public int levelPackIndex = 0;
        public Choice[] choice = new Choice[0];
}
