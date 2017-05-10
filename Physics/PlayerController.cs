using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int _health=100;
    public void GotHit(int points)
    {
        _health-=points;
    }

}
