﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    public int Cash { get; set; }
    public int Day { get; set; }
    public float PopulationCurrent { get; set; }
    public float PopulationCeiling { get; set; }
    public int JobsCurrent { get; set; }
    public int JobsCeiling { get; set; }
    public float Food { get; set; }

    public int[] buildingCounts = new int[4];

    public AudioSource endTurnSound;

    private UIController uiController;

	// Use this for initialization
	void Start () {
        uiController = GetComponent<UIController>();

        Cash = 1000;
        Food = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndTurn() {
        Day++;

        CalculateCash();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();

        Debug.Log("Day ended.");

        uiController.UpdateCityData();
        uiController.UpdateDayCount();

        Debug.LogFormat(
            "Jobs: {0}/{1}, Cash: {2}, Population: {3}/{4}, Food: {5}",
            JobsCurrent, JobsCeiling, Cash, PopulationCurrent, PopulationCeiling, Food
        );

        endTurnSound.Play();
    }

    void CalculateJobs() {
        JobsCeiling = buildingCounts[3] * 10;
        JobsCurrent = Mathf.Min((int)PopulationCurrent, JobsCeiling);
    }

    void CalculateCash() {
        Cash += JobsCurrent * 2;
    }

    public void DepositCash(int cash) {
        Cash += cash;
    }

    void CalculateFood() {
        Food += buildingCounts[2] * 4f;
    }

    void CalculatePopulation() {
        PopulationCeiling = buildingCounts[1] * 5;
        
        if (Food >= PopulationCurrent && PopulationCurrent < PopulationCeiling) {
            Food -= PopulationCurrent * 0.25f;
            PopulationCurrent = Mathf.Min(PopulationCurrent += Food * 0.25f, PopulationCeiling);
        } else if (Food < PopulationCurrent) {
            PopulationCurrent -= (PopulationCurrent - Food) * 0.5f;
        }
    }
}
