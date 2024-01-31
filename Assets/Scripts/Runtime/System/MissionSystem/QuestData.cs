
using UnityEngine;

public  struct QuestData
{
    public string IdMission;
    public int CurrentCount;
    public bool IsDone;

    public QuestData(string idMission , int currentCount ,bool isDone)
    {
        IdMission = idMission;
        CurrentCount = currentCount;
        IsDone = isDone;
    }
}
