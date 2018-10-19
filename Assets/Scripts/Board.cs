using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    // siatka na budynki o rozmiarach mapy
    private Building[,] buildings = new Building[100, 100];

    public AudioSource buySoldSound;

	// Use this for initialization
	void Start () {
		
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
