using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHero : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.manager.hero = gameObject;
        Debug.Log(GameManager.manager.hero);
    }
}
