using UnityEngine;

[CreateAssetMenu(fileName = "New Death Count Data", menuName = "Death Count Data")]
public class DeathCountData : ScriptableObject
{
    public int deathCount;

    public void ResetDeathCount()
    {
        deathCount = 0;
    }

    public void IncrementDeathCount()
    {
        deathCount++;
    }
}
