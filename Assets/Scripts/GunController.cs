using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GunController : MonoBehaviour
{

    [SerializeField] float shootPower,spread;
    [SerializeField] Camera fpsCam;
    [SerializeField] Transform bulletStartPoint;
    [SerializeField] TextMeshPro usedBulletCountText;
    [SerializeField] GameObject bulletPrefab;
    
    [SerializeField] GameObject panel;
    int usedBulletCount=0;

    public void OnFire(InputAction.CallbackContext context)
    {
        if(panel.activeSelf )return;
       if(context.performed){
           Fire();
       } 
    }
    private void Fire()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0)); // Center of screen
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(100);

        Vector3 directionSpreadless = targetPoint -bulletStartPoint.position;
        spread = Settings.Instance.SpreadAmount;
        for (int i = 0; i < Settings.Instance.BulletPerTap; i++)
        {
            float x = Random.Range(-spread,spread);
            float y = Random.Range(-spread,spread);
            Vector3 directionWithSpread = directionSpreadless+ new Vector3(x,y,0);
            GameObject newBullet = Instantiate(bulletPrefab,bulletStartPoint.position,Quaternion.identity);
            newBullet.transform.forward = directionWithSpread.normalized;
            newBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootPower,ForceMode.Impulse);
            newBullet.GetComponent<MeshRenderer>().material.color=Settings.Instance.BulletColor;
            usedBulletCount++;
        }
        usedBulletCountText.text = usedBulletCount.ToString();
    }
}
