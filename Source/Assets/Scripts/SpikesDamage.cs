﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    public bool m_Started;
    public bool start = false;
    public bool damage = false;

    public void MyCollision()
    {
        Collider[] playerColliders = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.LookRotation(Vector3.forward, Vector3.up));
        int i = 0;

        //Check when there is a new collider coming into contact with the box
        while (i < playerColliders.Length)
        {
            //Damage player
            //Debug.Log("Hit : " + playerColliders[i].name + i);
            if (playerColliders[i].tag == "Player")
            {
                if (!start || !damage)
                {
                    start = true;
                }
                
                if (damage)
                {
                    PlayerStats player = playerColliders[i].GetComponent<PlayerStats>();
                    player.TakeDamage(Random.Range(8, 10));
                    damage = false;
                }
            }

            //Increase the number of Colliders in the array
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
