using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test_For_Infect : MonoBehaviour
{

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void On_Particle_Collision()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

    }
}
