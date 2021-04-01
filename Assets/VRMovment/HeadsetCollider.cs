using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsetCollider : MonoBehaviour
{
    public GameObject CameraRig = null;
    public float ColliderSphereSize = 0.2f;

    private Vector3 oldPosition = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (transform.position - oldPosition).normalized;
        float elapsedDistance = Vector3.Distance(oldPosition, transform.position);

        RaycastHit hit;

        bool hitObstacle = Physics.Raycast(oldPosition, dir, out hit, elapsedDistance + ColliderSphereSize);

        if (hitObstacle)
        {
            Vector3 newPos = (transform.position + (dir*elapsedDistance)) - hit.point;

            CameraRig.transform.position += newPos;
        }

        oldPosition = transform.position;
    }
}
