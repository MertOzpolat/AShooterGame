using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float lifeTime = 1;
    Rigidbody rg;
    [SerializeField] GameObject ExplosionEffect;

    void Start(){
        transform.localScale *=Settings.Instance.BulletSize;
        rg = GetComponent<Rigidbody>();
        rg.mass = Mathf.Pow(Settings.Instance.BulletSize,3);
        if(Settings.Instance.Explosive)
            Invoke("Explode",lifeTime);
        else
            Invoke("Dismiss",lifeTime);
    }

    void Explode(){
        Instantiate(ExplosionEffect,transform.position,Quaternion.identity);
        Dismiss();
    }
    void Dismiss(){
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision){
        rg.velocity=Vector3.zero;
        rg.freezeRotation=true;
    }
    
}
