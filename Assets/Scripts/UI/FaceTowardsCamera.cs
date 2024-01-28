using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTowardsCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        transform.LookAt(Camera.main.transform, Vector3.up);
        transform.Rotate(new Vector3(0,180,0));
    }

    private void OnDrawGizmos()
    {
        LookAtCamera();
    }
}
