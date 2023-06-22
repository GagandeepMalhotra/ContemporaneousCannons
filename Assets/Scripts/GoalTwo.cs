using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTwo : MonoBehaviour
{
    public bool goal2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Ball")
        {
            Destroy(other.gameObject);
            Component halo = GetComponent("Halo"); halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
            goal2 = true;
        }
    }
}
