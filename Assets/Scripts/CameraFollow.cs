using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] GameObject target;
    [SerializeField] float speed = 4;
    [SerializeField] Vector2 posOffset;
    [SerializeField] bool visualizeBoundaries;

    [Header("Limits")]
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float topLimit;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = target.transform.position;

        endPos.x = Mathf.Clamp(endPos.x, leftLimit, rightLimit) + posOffset.x;
        endPos.y = Mathf.Clamp(endPos.y, bottomLimit, topLimit) + posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (!visualizeBoundaries) return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(rightLimit, topLimit));
    }
}
