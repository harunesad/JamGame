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
                    GameManager.manager.pointIndex = i;
                }
            }
            GameManager.manager.heroPoint = gameObject;
            GameManager.manager.SpawnObject();
            GameManager.manager.hero = null;
        }
    }
}
