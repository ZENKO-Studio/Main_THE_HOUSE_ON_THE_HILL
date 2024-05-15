using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtilities : MonoBehaviour
{
    public static bool IsObjectInView(Camera camera, GameObject obj)
    {
        // Get the object's renderer component
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null)
        {
            // If there's no renderer, consider it out of view
            return false;
        }

        // Get the object's bounds
        Bounds bounds = renderer.bounds;

        // Get the camera's view frustum planes
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        // Test if the object's bounds intersect with the view frustum planes
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
