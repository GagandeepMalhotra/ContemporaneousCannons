using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class customGrid : MonoBehaviour
{
    public GameObject asset;
    public GameObject target;
    Vector3 truePos;
    public float gridSize;

    void LateUpdate()
    {
        truePos.x = Mathf.Round(target.transform.position.x / gridSize) * gridSize;
        truePos.y = Mathf.Round(target.transform.position.y / gridSize) * gridSize;
        truePos.z = Mathf.Round(target.transform.position.z / gridSize) * gridSize;

        asset.transform.position = truePos;
    }
}
