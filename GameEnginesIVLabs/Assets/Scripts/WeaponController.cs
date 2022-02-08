using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Rifle,
    Pistol,
    Sniper,
    Smg
}

public enum FiringPattern
{
    Single,
    Automatic,
    SemiAutomatic
}
[System.Serializable]
public struct WeaponStats
{
    public WeaponType weaponType;
    public FiringPattern firingPattern;
    public string name;
    public float damage;
    public float clipSize;
    public float bulletsInClip;
    public float fireStartDelay;
    public float fireRate;
    public float fireDistance;
    public bool repeating;
    public LayerMask weaponHitLayer;
}

public class WeaponController : MonoBehaviour
{
    public Transform socketIKLeftHand;

    public WeaponStats weaponStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
