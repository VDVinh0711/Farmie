


[System.Serializable]
public struct CopSaveState 
{
    public int landID;
    public string seedData;
    public int spriteNumber;
    public float timeGrow;

    public CopSaveState(int landId,string seedData, int spriteNumber, float timeGrow)
    {
        landID = landId;
        this.seedData = seedData;
        this.spriteNumber = spriteNumber;
        this.timeGrow = timeGrow;
    }
}
