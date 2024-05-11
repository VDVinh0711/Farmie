

[System.Serializable]
public struct AnimalData
{
  public string ID;
  public float currentTime;
  public bool ISsick;
  public bool ISHurry;
  public bool Isnormal;
  public bool IsHarvest;

  public AnimalData(string id, float currentTime, bool ssick, bool isHurry, bool isnormal, bool isHarvest)
  {
    ID = id;
    this.currentTime = currentTime;
    ISsick = ssick;
    ISHurry = isHurry;
    Isnormal = isnormal;
    IsHarvest = isHarvest;
  }
}
