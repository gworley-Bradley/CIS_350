using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootwithRaycast : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public float hitForce = 10f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { Shoot();}

    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);



            //get the target script off the hit object
           // Target target = hitInfo.transform.gameObject.GetComponent<Target>();
            Enemy enemy = hitInfo.transform.gameObject.GetComponent<Enemy>();

            //if the target script was found, make the target take damage
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
            
        }
    }
}
