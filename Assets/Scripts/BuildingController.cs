using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingController : MonoBehaviour {

    [SerializeField]
    private City city;
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    private Building[] buildings;
    [SerializeField]
    private Board board;
    private Building selectedBuilding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift)) {
            InteractWithBoard(0);
        } else if (Input.GetMouseButtonDown(0) && selectedBuilding != null) {
            InteractWithBoard(0);
        }

        if (Input.GetMouseButtonDown(1)) {
            InteractWithBoard(1);
        }
	}

    private void InteractWithBoard(int action) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // jesli kliknieto na jakis obszar mapy
        if (Physics.Raycast(ray, out hit)) {
            Vector3 gridPosition = board.CalculateGridPosition(hit.point);

            // !EventSystem.current.IsPointerOverGameObject() zapobiega stawiania budynkow
            // w momencie klikniecia przycisku w menu budowy (ogolnie dziala na wszystkie lementy UI)
            if (!EventSystem.current.IsPointerOverGameObject()) {
                if (action == 0 && board.CheckForBuildingAtPosition(gridPosition) == null) {
                    if (city.Cash >= selectedBuilding.cost) {
                        city.DepositCash(-selectedBuilding.cost);
                        uiController.UpdateCityData();
                        city.buildingCounts[selectedBuilding.id]++;

                        board.AddBuilding(selectedBuilding, gridPosition);
                    }
                } else if (action == 1 && board.CheckForBuildingAtPosition(gridPosition) != null) {
                    city.DepositCash(board.CheckForBuildingAtPosition(gridPosition).cost / 2);

                    board.RemoveBuilding(gridPosition);

                    uiController.UpdateCityData();
                }
            }
        }
    }

    // po kliknieciu na budynek w menu budowy ustawia odpowiedni indeks budynku do zbudowania
    public void EnableBuilder(int buildingIndex) {
        selectedBuilding = buildings[buildingIndex];
        Debug.Log("Selected building: " + selectedBuilding.buildingName);
    }
}
