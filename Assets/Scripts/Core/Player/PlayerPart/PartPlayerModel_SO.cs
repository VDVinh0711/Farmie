
using UnityEngine;
using UnityEngine.U2D.Animation;


[CreateAssetMenu(menuName = "Creat PartPlayer / New PartPlayer")]
public class PartPlayerModel_SO : ScriptableObject
{
   [SerializeField] private string id;
   [SerializeField] private BodyPartType type;
   [SerializeField] private string namePart;
   private SpriteLibraryAsset spriteLibraryAsset;


   public string ID => id;
   public BodyPartType Type => type;
   public string NamePart => namePart;
   public SpriteLibraryAsset SpriteLibraryAsset;


   private void OnValidate()
   {
       id = this.name;
   }


   public static PartPlayerModel_SO Get_Part_by_ID(string id)
   {
       var parstRes = Resources.LoadAll<PartPlayerModel_SO>("ScriptAbleOBJ/PartPlayer");
       foreach (var part in parstRes)
       {
           if(part.ID != id) continue;
           return part;
       }

       return null;
   }
}
