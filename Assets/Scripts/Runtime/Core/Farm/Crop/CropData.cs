

[System.Serializable]
public struct CropData 
{
    public int landID;
    public string idseed;
    public int spriteNumber;
    public GameTime timeOut;
    public CropData(int landId,string idseed, int spriteNumber,GameTime timeout)
    {
        landID = landId;
        this.idseed = idseed;
        this.spriteNumber = spriteNumber;
        this.timeOut = timeout;
    }
}
