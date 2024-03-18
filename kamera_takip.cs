using UnityEngine;

public class kamera_takip : MonoBehaviour
{
    [SerializeField] private GameObject targetObje;
    private Vector3 kameraOffset = new Vector3(0,0,-10);

    void LateUpdate()
    {
        transform.position = targetObje.transform.position + kameraOffset;
    }
}
