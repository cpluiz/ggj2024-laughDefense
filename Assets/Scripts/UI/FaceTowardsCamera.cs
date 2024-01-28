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
        transform.LookAt(Camera.main.transform, transform.up);
        transform.Rotate(new Vector3(0,180,0));
    }

    private void OnDrawGizmos()
    {
        LookAtCamera();
    }
}
