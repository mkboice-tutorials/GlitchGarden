﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    public Camera myCamera;

    private GameObject parent;
    private StarDisplay starDisplay;

    void Start()
    {
        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }

        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRotation = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, roundedPos, zeroRotation);
        newDefender.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
