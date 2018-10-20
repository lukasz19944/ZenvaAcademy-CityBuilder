using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    // siatka na budynki o rozmiarach mapy
    private Building[,] buildings;

    public AudioSource buySoldSound;

    private int mapSize;

    private int smallMapSize = 50;
    private int mediumMapSize = 100;
    private int largeMapSize = 200;

	// Use this for initialization
	void Start () {
		switch (PlayerPrefs.GetString("MapSize")) {
            case "SMALL":
                mapSize = smallMapSize;  
                break;
            case "MEDIUM":
                mapSize = mediumMapSize;
                break;
            case "LARGE":
                mapSize = largeMapSize;
                break;
        }

        gameObject.transform.position = new Vector3(mapSize / 2f, 0f, mapSize / 2f);
        gameObject.transform.localScale = new Vector3(mapSize, 1f, mapSize);

        buildings = new Building[mapSize, mapSize];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBuilding(Building building, Vector3 position) {
        Building buildingToAdd = Instantiate(building, position, Quaternion.identity);

        buildings[(int)position.x, (int)position.z] = buildingToAdd;

        buySoldSound.Play();
    }

    // zwraca budynek na danej pozycji
    public Building CheckForBuildingAtPosition(Vector3 position) {
        return buildings[(int)position.x, (int)position.z];
    }

    // usuwanie budynku
    public void RemoveBuilding(Vector3 position) {
        Destroy(buildings[(int)position.x, (int)position.z].gameObject);
        buildings[(int)position.x, (int)position.z] = null;

        buySoldSound.Play();
    }

    // zamiana współrzędnych kliknięcia myszką na liczby całkowite, aby budynku wstawiane byly w siatce
    public Vector3 CalculateGridPosition(Vector3 posistion) {
        return new Vector3(Mathf.Round(posistion.x), 0.5f, Mathf.Round(posistion.z));
    }
}
