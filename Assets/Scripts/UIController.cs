using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private City city;

    [SerializeField]
    private Text dayText;
    [SerializeField]
    private Text cityText;

	// Use this for initialization
	void Start () {
        city = GetComponent<City>();

        UpdateCityData();
    }

    public void UpdateDayCount() {
        dayText.text = "Day " + city.Day;
    }

    public void UpdateCityData() {
        cityText.text = string.Format(
            "Cash: ${0} (+${1})\nPopulation: {2}/{3}\nFood: {4}\nJobs: {5}/{6}",
            city.Cash, city.JobsCurrent * 2,
            (int)city.PopulationCurrent, (int)city.PopulationCeiling, 
            (int)city.Food,
            city.JobsCurrent, city.JobsCeiling 
        );
    }
}
