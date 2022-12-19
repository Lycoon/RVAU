using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootBullet());
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                ShootRay();
            else
                StartCoroutine(ShootBullet());
        }
    }

    void ShootRay()
    {
        RaycastHit hitRay;
        if (Physics.Raycast(transform.position, transform.forward, out hitRay, 100))
        {
            GameObject hit = hitRay.collider.gameObject;
            hit.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        }
    }

    IEnumerator ShootBullet()
    {
        GameObject instanceBullet = Instantiate(bullet, transform.position, transform.rotation);
        instanceBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1700);
        instanceBullet.transform.Rotate(90, 0, 0);

        yield return new WaitForSeconds(3.0f);

        GameObject.Destroy(instanceBullet);
    }
}
