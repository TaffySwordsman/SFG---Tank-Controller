using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, mask))
            transform.LookAt(new Vector3(raycastHit.point.x, this.transform.position.y, raycastHit.point.z));
    }
}
