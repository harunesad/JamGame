using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHero : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.manager.hero = gameObject;
    }
}
