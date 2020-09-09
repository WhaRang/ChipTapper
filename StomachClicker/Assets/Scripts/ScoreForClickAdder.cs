using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreForClickAdder : MonoBehaviour, IPointerClickHandler
{
    public ScoreForClickPrefabBehaviour ScoreTextPrefab;

    public void OnPointerClick(PointerEventData data)
    {
        Vector3 newPosition = data.pointerCurrentRaycast.worldPosition;
        newPosition.z = 0.0f;
        int score = (TaskManager.manager.GetLevel() + 1) / 2;
        ScoreForClickPrefabBehaviour ScoreText = 
            Instantiate(ScoreTextPrefab, newPosition, Quaternion.identity);
        ScoreText.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        ScoreTextPrefab.SetText("+" + score + " pt.");    
        ScoreManager.manager.AddScore(score);
    }
}
