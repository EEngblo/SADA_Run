using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public Camera camera;
    public GameObject player;


    public float speed = 0.5f;
    float cameraSize = 5f;


    public float Maxsize = 10f, Minsize = -3f;
	void Update () {

        cameraSize = 5f + player.transform.position.y;

        if(cameraSize > Maxsize)
            cameraSize = Maxsize;
        if(cameraSize < Minsize)
            cameraSize = Minsize;

        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraSize, Time.deltaTime / speed);

	}
}
