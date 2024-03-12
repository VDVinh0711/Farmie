using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(menuName = "New S0_Bodypart" , fileName = "SO_BoDyPart")]
public class SO_body_part : ScriptableObject
{
    public string bodypartAnimationID;
    public string namebody;
    
    private void OnValidate()
    {
        bodypartAnimationID = this.name;
    }
    public static SO_body_part Get_body_Part_ByID(string path,string id)
    {
        return Resources.Load<SO_body_part>(path+"/"+id);
    }
}