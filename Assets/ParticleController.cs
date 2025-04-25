using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem MovementParticle;
    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D PlayerRb;

    float counter;
    private void Update()
    {
        counter += Time.deltaTime;
        if (Mathf.Abs (PlayerRb.velocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                MovementParticle.Play();
                counter = 0;
            }
            
        }
    }
}
