

[System.Serializable]
public struct LandSaveState 
{
    public Land.LandStatus statusLand;
    public GameTime timeWatered;
    public bool isPlanted;
    public LandSaveState(Land.LandStatus statusLand, GameTime timeWatered,bool isPlanted)
    {
        this.statusLand = statusLand;
        this.timeWatered = timeWatered;
        this.isPlanted = isPlanted;
    }
}
