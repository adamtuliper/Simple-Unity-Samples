using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///***NOTE*** This functionality is called from the FindObject code.
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int _health=100;
    public void GotHit(int points)
    {
        _health-=points;
    }

}
