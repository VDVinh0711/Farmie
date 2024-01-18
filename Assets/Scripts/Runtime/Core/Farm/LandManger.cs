using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public class LandManager : MonoBehaviour,ISaveSystem
{
    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private GameObject PlanPrefabs;
    public float n_distanceX,n_distanceY;

    private void Awake()
    {
        RegisterIDLand();
    }
    private void InstanLand()
    {
        if(transform.childCount > 0) return;
        SpawnLand();
    }
    private void SpawnLand()
    {
        for (var i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
               var objPlan =  Instantiate(PlanPrefabs, transform);
           
               objPlan.transform.position = new Vector2(transform.position.x+ (i *n_distanceX), transform.position.y+(j*n_distanceY));
            }
        }   
        RegisterIDLand();
    }
    private void RegisterIDLand()
    {
        int i = 0;
        foreach (Transform obj in transform)
        {
            var landScript = obj.GetComponent<Land>();
            landScript.ID = i;
            i++;
        }
    }

    public object SaveData()
    {
        Dictionary<int,LandData> landDatas = new Dictionary<int, LandData>();
        Dictionary<int, CropData> cropdatas = new Dictionary<int, CropData>();
        foreach (var land in GetComponentsInChildren<Land>())
        {
            LandData newLandata = new LandData(land.LandState.ToString(), land.lastTimeWatered,land.planting);
            landDatas.Add(land.ID,newLandata);
            if(!land.planting) continue;
            var cropscript = land.transform.GetChild(1).GetComponent<CropBehavious>();
            CropData newCrop = new CropData(land.ID, cropscript.IDSeed, cropscript.Sprite,TimeManager.Instance.GetGameTime());
            cropdatas.Add(land.ID,newCrop);
        }
        var ListDataFarm = new  Tuple<Dictionary<int, LandData>, Dictionary<int, CropData>>(landDatas,cropdatas);
        return ListDataFarm;
    }

    public void LoadData(object state)
    {
        var dataFarm = JsonConvert.DeserializeObject<Tuple<Dictionary<int, LandData>, Dictionary<int, CropData>>>(state.ToString());
        var landDatas = dataFarm.Item1;
        var cropdatas = dataFarm.Item2;
        InstanLand();
        foreach (var land in GetComponentsInChildren<Land>())
        {
            var landata = landDatas[land.ID];
            land.LandState = (Land.LandStatus)Enum.Parse(typeof(Land.LandStatus),landata.LandState);
            land.lastTimeWatered = new GameTime(landata.LastWatered) ;
            land.planting = landata.IsPlanted;
            if(!landata.IsPlanted) continue;
            var crop = land.SpawmCrop();
            var cropdata = cropdatas[land.ID];
            var seed = ItemObject.getItemByID(cropdata.idseed) as SeedObject;
            crop.LoadCrop(seed,cropdata.spriteNumber,cropdata.timeOut);
        }
    }
}
