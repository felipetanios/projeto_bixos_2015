using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Spot : MonoBehaviour
{

    [HideInInspector] public Vector3 spotPosition;
    [HideInInspector] public Vector3 spotScale;
    [HideInInspector] public bool isAvailable;
    public bool isWindow;
    public bool isMirror;
    public bool isHighPriority;

    void Awake()
    {
        spotPosition = this.transform.position;
        spotScale = this.transform.lossyScale;
        isAvailable = true;
    }

    #if UNITY_EDITOR
    static readonly Vector3 gizmoSize = new Vector3(.5f, .5f, 0);
    void OnDrawGizmos()
    {
        if (isAvailable)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawCube(transform.position, gizmoSize);
    }
    #endif
}
