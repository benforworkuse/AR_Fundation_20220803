
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

namespace Ben
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class TapToSpawnObject : MonoBehaviour
    {
        [SerializeField, Header("要生成的物件")] private GameObject goSpawnObj;
        private ARRaycastManager arManager;
        private Vector2 touchPoint;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();

        private void Awake()
        {
            arManager = GetComponent<ARRaycastManager>();
        }
        private void Update()
        {
            TapAndSpawn();
        }
        private void TapAndSpawn() {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                touchPoint = Input.mousePosition;
                if (arManager.Raycast(touchPoint, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose pose = hits[0].pose;

                    GameObject temp = Instantiate(goSpawnObj, pose.position, Quaternion.identity);
                    Vector3 cameraPos = transform.position;
                    cameraPos.y = temp.transform.position.y;
                    temp.transform.LookAt(cameraPos);
                }
            }
        }

    }

}

