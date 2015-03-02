using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
 
    public Interface interfaceScript;

    [HideInInspector] public int activatedProfs;

    List<Spot> spots = new List<Spot>();
    List<Spot> highPrioritySpots = new List<Spot>();
    int totalSpots;

    private int mouseClicks;
    private float gameTime;

    // Is the game finished?
    [HideInInspector] public bool finished = false;

    // Is the prof on screen?
    [HideInInspector] public bool profOnScreen = false;

    [HideInInspector] public float score;
    public float scoreIdeal = 700;

    // Use this for initialization
    void Awake()
    {
        activatedProfs = GameObject.FindGameObjectsWithTag("Prof").Length;

        GameObject[] spotsObjects;
        spotsObjects = GameObject.FindGameObjectsWithTag("Spot");

        totalSpots = spotsObjects.Length;

        foreach (GameObject spot in spotsObjects)
        {
            var spotScript = spot.GetComponent<Spot>();
            spots.Add(spotScript);
            if (spotScript.isHighPriority)
                highPrioritySpots.Add(spotScript);
        }
    }

    void Update()
    {
        if (!finished) {
            if (Input.GetMouseButtonDown(0))
                mouseClicks++;
            gameTime += Time.deltaTime;
            if (activatedProfs == 0 && !profOnScreen)
                finished = true;
        } else if (finished) {
            MouseManager.Instance.ResetCursor();
            score = scoreIdeal / (gameTime * mouseClicks) * 1000;
            interfaceScript.Score(((int) score).ToString());
            enabled = false;
        }
    }

    public Spot FindSpot()
    {
        if (Random.Range(0f, 1f) < .4f)
        {
            // Try high priority Spot first
            var prioritySpot = highPrioritySpots[Random.Range(0, highPrioritySpots.Count)];
            if (prioritySpot.isAvailable)
                return prioritySpot;
        }

        // Normal spots
        Spot chosenSpot = spots[Random.Range(0, totalSpots)];

        // Enquanto nao encontra uma posicao valida
        for (int i = 0; i < totalSpots && (!chosenSpot.isAvailable || MouseManager.Instance.IsMouseNear(chosenSpot)); i++)
            chosenSpot = spots[Random.Range(0, totalSpots)];

        if (!chosenSpot.isAvailable)
            return null;

        return chosenSpot;
    }
}