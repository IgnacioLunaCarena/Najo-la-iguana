using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IguanaController : MonoBehaviour
{
    [SerializeField] private IguanaData iguanaData;
    [SerializeField] private float regenCooldown;
    private bool inHighSunZone = false;
    private bool canRegen = false;
    private float timeToRegen = 0f;

    //Events
    public static event Action<int> onLifeChange;
    public static event Action onHighSunZoneEnter;
    public static event Action onSafeZoneEnter;

    private void Awake()
    {
        IguanaColorController.onSunHurt += OnSunHurtHandler;
        EagleAttack.onPlayerAttacked += OnPlayerAttackedHandler;
    }

    void Start()
    {
        iguanaData.life = 6;
        Debug.Log(iguanaData.life);
        onLifeChange?.Invoke(iguanaData.life);
        transform.position = new Vector3(121.8f, 30.3f, 589.7f);
        Quaternion initialRotation = Quaternion.Euler(0f, 392.614f, 0);
        transform.rotation = initialRotation;
    }
    private void Update()
    {
        if (inHighSunZone)
            onHighSunZoneEnter?.Invoke();
        else
            onSafeZoneEnter?.Invoke();
       
        if (iguanaData.life < 6)
        {
            if (canRegen)
            {
                iguanaData.life++;
                onLifeChange?.Invoke(iguanaData.life);
                canRegen = false;
                timeToRegen = 0;
            }
            else
            {
                timeToRegen += Time.deltaTime;
                Debug.Log(timeToRegen);
            }

            if (timeToRegen >= regenCooldown)
                canRegen = true;
        }
    }
    
    public void GetDamage(int damage)
    {
        iguanaData.life -= damage;
        onLifeChange?.Invoke(iguanaData.life);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
            GetDamage(1);
    }

    public void HighSunZone()
    {
        inHighSunZone = !inHighSunZone;
        //Debug.Log(inHighSunZone);
    }

    private void OnSunHurtHandler()
    {
        GetDamage(1);
    }

    private void OnPlayerAttackedHandler()
    {
        GetDamage(1);
    }

    private void OnDestroy()
    {
        IguanaColorController.onSunHurt -= OnSunHurtHandler;
        EagleAttack.onPlayerAttacked -= OnPlayerAttackedHandler;
    }
}
