using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Tile : MonoBehaviour
{
    public int Answer;
    int z_rotation;
    int Euler_z;

    public void Rotation()
    {
        z_rotation -= 90;
        if(z_rotation== -360)
        {
            z_rotation = 0;
        }
        switch(z_rotation)
        {
            case -90:
                Euler_z = 270;
                break;
            case -180:
                Euler_z = 180;
                break;
            case -270:
                Euler_z = 90;
                break;
            case 0:
                Euler_z = 0;
                break;
        }
        this.transform.rotation = Quaternion.Euler(0,0, z_rotation);
    }
}
