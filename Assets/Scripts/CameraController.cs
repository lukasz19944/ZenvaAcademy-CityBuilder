using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float zoomMultiplier = 3f;

    private Vector3 mouseOriginPoint;
    private Vector3 offset;

    private bool dragging = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // przycinanie przyblizania kamery do min i max
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomMultiplier * Camera.main.orthographicSize, 2.5f, 50f);

        // przeciaganie środkowym przyciskiem myszy
        if (Input.GetMouseButton(2)) {
            offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            
            if (!dragging) {
                dragging = true;

                mouseOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        } else {
            dragging = false;
        }

        if (dragging) {
            transform.position = mouseOriginPoint - offset;
        }
        

    }
}
