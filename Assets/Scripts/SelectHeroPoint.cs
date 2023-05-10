using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHeroPoint : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.manager.hero != null)
        {
            for (int i = 0; i < GameManager.manager.points.Count; i++)
            {
                if (gameObject.name == GameManager.manager.points[i].name)
                {
                    GameManager.manager.pointCount = i;
                }
            }
            GameManager.manager.heroPoint = gameObject;
            Debug.Log(GameManager.manager.heroPoint);
            GameManager.manager.SpawnObject();
            GameManager.manager.hero = null;
        }
    }
}
