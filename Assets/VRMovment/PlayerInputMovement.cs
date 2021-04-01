using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerInputMovement : MonoBehaviour
{

    public float movementSpeed = 5;
    public GameObject camera = null;

    private SteamVR_Behaviour_Vector2 movementinput = null;
    // Start is called before the first frame update
    void Start()
    {
        movementinput = GetComponent<SteamVR_Behaviour_Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentAxis = movementinput.vector2Action.axis;

        Vector3 currentAxisPlusY = new Vector3(currentAxis.x, 0, currentAxis.y);

        Vector3 cameraForewardNoY = camera.transform.forward;
        Vector3 cameraRightNoY = camera.transform.right;

        cameraForewardNoY.y = 0;
        cameraRightNoY.y = 0;

        Vector3 translatesMovement = new Vector3(0, 0, 0);
        translatesMovement += cameraForewardNoY * currentAxis.y;
        translatesMovement += cameraRightNoY * currentAxis.x;

        transform.Translate(translatesMovement * (movementSpeed * Time.deltaTime), Space.World);
    }
}
