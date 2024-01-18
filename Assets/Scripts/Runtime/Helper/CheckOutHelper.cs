
using UnityEngine;

public static class CheckOutHelper 
{
    public static bool checkPosInpanel(RectTransform panel)
    {

        Vector3 mousePosition = Input.mousePosition;
       Vector3[]  corners = new Vector3[4];
       panel.GetWorldCorners(corners);
        for (int i = 0; i < corners.Length; i++) {
            if (mousePosition.x >= corners[i].x && mousePosition.x <= corners[i + 1].x &&
                mousePosition.y >= corners[i].y && mousePosition.y <= corners[i + 1].y)
            {

                return false;
            }
        }

        return true;

    }
}
