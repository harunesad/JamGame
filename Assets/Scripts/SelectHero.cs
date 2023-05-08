using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHero : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SpawnManager.spawn.spawnPrefab = gameObject;
        Debug.Log(SpawnManager.spawn.spawnPrefab);
    }
}
