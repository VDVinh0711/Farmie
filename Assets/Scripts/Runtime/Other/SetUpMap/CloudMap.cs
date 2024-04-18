using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudMap : MonoBehaviour
{
   [SerializeField] private List<Transform> _cloudPreFabs = new ();
   [SerializeField] private List<Transform> _pointsSpawn = new ();
   [SerializeField] private Transform _holderSpawn;
   [SerializeField] private float _timeSpawn;
   [SerializeField] private bool _isSpawn;

   private void Start()
   {SpawnCloud();
      StartCoroutine(ActionSpawn());
   }

   public Transform GetRamDomSpawnCloud()
   {
      var indexrandom = Random.Range(0, _cloudPreFabs.Count);
      return _cloudPreFabs[indexrandom];
   }
   
   private Vector2 getRamDomPoint()
   {
      var indexrandom = Random.Range(0, _pointsSpawn.Count);
      return _pointsSpawn[indexrandom].transform.position;
   }
   IEnumerator ActionSpawn()
   {
      while (_isSpawn)
      {
         yield return new WaitForSeconds(_timeSpawn);
         SpawnCloud();
      }
   }
   
   public void SpawnCloud()
   {
      var cloudSpawn = PollingObject.Instance.GetObj(GetRamDomSpawnCloud().gameObject.name);
      if (cloudSpawn == null)
      {
         cloudSpawn = Instantiate(GetRamDomSpawnCloud());
         cloudSpawn.gameObject.SetActive(false);
      }
      cloudSpawn.gameObject.transform.position = getRamDomPoint();
      cloudSpawn.SetParent(_holderSpawn);
      cloudSpawn.gameObject.SetActive(true);
   }
}
