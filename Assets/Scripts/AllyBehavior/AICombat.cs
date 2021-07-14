using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
    
{
    public AIMovement AIMovement;
    public float damageValue;
    public float fireRate;
    public float dispersion;
    public bool firing;
    public Transform firePos;
    private float roundsToFire;
    private float roundsPerSecond;
    public GameObject aiBullet;
    public float ammoPool = 5f;
    public float maxAmmo = 60;
    public float reloadTime = 3f;
    public float magCount = 6f;
    public bool startReload;  
    private bool runOnce;
    // Start is called before the first frame update
    void Start()
    {
        roundsPerSecond = fireRate / 60;
        AIMovement = GetComponent<AIMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firing & ammoPool > 0 & !startReload)
        {
            CalculateRounds();
        }
        if (firing & ammoPool <= 0 & !startReload)
        {
            ReloadProtocol();
        }
        if (!firing & !startReload & ammoPool < (maxAmmo / 2))
        {
            ReloadProtocol();
        }
        
    }
    private void CalculateRounds()
    {
        roundsToFire += roundsPerSecond * Time.deltaTime;
        while (roundsToFire >= 1)
        {
            FireGun();
        }
    }
    private void FireGun()
    {
        Quaternion aimVector = Quaternion.RotateTowards(transform.rotation, Random.rotation, dispersion);
        GameObject instBullet = Instantiate(aiBullet, transform.position, aimVector) as GameObject;
        //reduce ammopoool by one
        roundsToFire -= 1;
        ammoPool -= 1;
    }
    private void ReloadProtocol()
    {
        startReload = true;
        runOnce = false;
        ammoPool = 0f;
        if (magCount > 0)
        {
            StartCoroutine(WaitForReload());
        }
        IEnumerator WaitForReload()
        {
            yield return new WaitForSeconds(reloadTime);
            magCount -= 1;
            ammoPool = maxAmmo;
            startReload = false;
        }
    }
}
