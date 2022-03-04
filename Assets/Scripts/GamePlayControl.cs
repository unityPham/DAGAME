
using UnityEngine;
using UnityEngine.EventSystems;
public class GamePlayControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        GameManager.THIS.GamePlayControl();
        Debug.Log("PointDown");
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log(name + "No longer being clicked");
    }
    public void MouseDown()
    {
        GameManager.THIS.GamePlayControl();
        Debug.Log("PointDown");
    }
}
