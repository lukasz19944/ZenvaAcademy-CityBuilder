using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUIController : MonoBehaviour {

    public GameObject mapSizePanel;

    public void StartGame(string size) {
        SceneManager.LoadScene("Game");

        PlayerPrefs.SetString("MapSize", size);
    }

    public void ShowMapSizePanel() {
        mapSizePanel.SetActive(!mapSizePanel.activeSelf);
    }
}
