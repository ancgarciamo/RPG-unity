using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int hp;
    protected int mp;
    protected int atk;
    protected int def;
    protected int res;
    protected int mag;
    protected int vel;

    public Character(int vida, int mana, int ataque, int defensa, int magia, int resistencia, int velocidad)
    {
        this.hp = vida;
        this.mp = mana;
        this.atk = ataque;
        this.def = defensa;
        this.mag = magia;
        this.res = resistencia;
        this.vel = velocidad;

    }

    public int takenDmg(int dmg)
    {
        int currentHp = hp;
        int finalDmg = dmg - ((this.def - 1) / 2);

        this.hp = currentHp - finalDmg;

        return finalDmg;
    }
    public int attack()
    {
        return this.atk;

    }
    public int vida()
    {
        return this.hp;
    }
    public int velocidad()
    {
        return this.vel;
    }
    public void comandos_defensa(bool fase_actual)
    {
        if (fase_actual == true)
        {
            this.def = this.def * 2;
        }
        else
        {
            this.def = this.def * (1 / 2);
        }



    }
}








