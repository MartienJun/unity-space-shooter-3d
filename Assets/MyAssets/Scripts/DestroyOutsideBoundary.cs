using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutsideBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider Other)
    {
        Destroy(Other.gameObject);
    }
}
