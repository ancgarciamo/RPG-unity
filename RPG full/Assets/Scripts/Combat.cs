using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public void assign_atributes(Character e)
    {
        float x = Random.Range(0, 1);
        if (x < 1 / 6)
        {
            //fire
        }else if (x < 2 / 6)
        {
            //water
        }
        else if (x < 3/ 6)
        {
            //earth
        }
        else if (x < 4 / 6)
        {
            //wind
        }
        else if (x < 5 / 6)
        {
            //lightning
        }
        else
        {
            // ice
        }
    }
}
