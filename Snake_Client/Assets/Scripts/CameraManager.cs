using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private void Start()
    {
        Transform camera = Camera.main.transform;
        camera.parent = transform;
        camera.localPosition = Vector3.zero;
    }

    private void OnDestroy()
    {
        if (!Camera.main) return;
        Transform camera = Camera.main.transform;
        camera.parent = null;
    }
}
