using UnityEngine;

[CreateAssetMenu(fileName = "New Score", menuName = "Game/Score")]
public class ScoreObject : ScriptableObject
{
    public int score = 0;
    public int wave = 1;
}
