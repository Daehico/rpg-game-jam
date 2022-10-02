using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float FlickerFrequency = 0.2f;
    public float FlickerVariance = 0.1f;

    private Light light;
    private Vector3 startPos;
    private float startIntensity;
    private float timer;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        startIntensity = light.intensity;
        startPos = transform.position;
        targetPos = transform.position;
        timer = Time.time + FlickerFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
        if(Time.time > timer)
        {
            var randomNumber = Random.Range(-FlickerVariance, FlickerVariance);
            light.intensity = startIntensity + randomNumber;
            targetPos = new Vector3(startPos.x + randomNumber, startPos.y + randomNumber, startPos.z + randomNumber);
            timer = Time.time + FlickerFrequency;
        }
    }
}
