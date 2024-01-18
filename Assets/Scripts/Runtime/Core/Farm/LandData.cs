

[System.Serializable]
public struct LandData
{
    public string LandState;
    public GameTime LastWatered;
    public bool IsPlanted;
    public LandData(string landState, GameTime lastWatered,bool isPlanted)
    {
        LandState = landState;
        LastWatered = lastWatered;
        IsPlanted = isPlanted;
    }
}
