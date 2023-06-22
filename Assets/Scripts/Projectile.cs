using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public Rigidbody bulletPrefabs;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    public GameObject pauseCanvas;

    public Vector3 targetAngle = new Vector3(90f, 180f, 0f);

    private Vector3 currentAngle;

    public int shots = 1;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        shots = 1;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (pauseCanvas.activeSelf == false && shots >= 1 && Physics.Raycast(camRay, out hit, 100f, (1 << LayerMask.NameToLayer("Planes") | (1 << LayerMask.NameToLayer("Objects")))))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f);

            transform.rotation = Quaternion.LookRotation(Vo);

            if (Input.GetMouseButtonDown(0) && shots >=1)
            {
                shots = shots - 1;
                Rigidbody obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                obj.velocity = Vo;
            }
        }
        else
        {
            cursor.SetActive(false);
            currentAngle = transform.eulerAngles;
            currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime*2),
             Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime*2),
             Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime*2));

            transform.eulerAngles = currentAngle;
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //define x and y distance
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        //create a float that represents our distance
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;
    }
}
