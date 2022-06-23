using UnityEngine;

public class Utils : MonoBehaviour
{
    /// <summary>
    /// Convert screen to world coordinates.
    /// Make sure to have the z value be the distance from the near clip plane to the object.
    /// If the game is 2d you can place the near clip plane where the object is and pass in
    /// the nearClipPlane directly.
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position) {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
}
