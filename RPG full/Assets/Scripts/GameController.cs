using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public Text vida_actual;
    public Text vida_maxima;
    public Text info_combate;
    public GameObject boton_ataque;
    public GameObject boton_defensa;
    public GameObject boton_objetos;
    public GameObject boton_atras;
    public GameObject boton_haste;
    private bool bandera =true;
    private bool boton_de_ataque =false;
    private bool boton_de_defensa = false;
    private bool boton_haste2=false;
    Character player = new Character(2800, 20, 100, 200, 100, 100, 30);
    Character enemy = new Character(2000, 10, 200, 50, 10, 0, 20);
    public int contador = 0;
    public int contador2 = 0;
    public bool turno = true;


    void Start()
    {

        vida_actual.text = player.vida() + "";
        vida_maxima.text = player.vida() + " / ";
        boton_atras.SetActive(false);
        
    }
    public bool turno_ataque()
    {
        bool bandera;
        if (contador2 == 0)
        {
            contador2 = contador2 + 1;
            bandera = true;
        }
        else if (contador2 > 1)
        {
            contador2 = 0;
            bandera = false;
        }
        else
        {
            bandera = false;
        }
        return bandera;


    }



    public void AtacarComando()
    {
        boton_de_ataque = true;
        boton_ataque.SetActive(false);
        int daño1 = enemy.takenDmg(player.attack());
        info_combate.text = "le quitastes  " + daño1 + " puntos de vida al enemigo este ahora tiene " + enemy.vida() + "puntos de vida";
        bandera = false;
        //turno_ataque();
        contador = 0;
        if (contador2 == 1) { turno = false; }


    }
    public void DefenderComando()
    {
        boton_de_defensa = true;
        int def1=player.comandos_defensa(true);
        info_combate.text = "tu defensa ahora tiene un valor de " + def1;
        bandera = false;
        //turno_ataque();
        contador = 0;
        if (contador2 == 1) { turno = false; }




    }
    public void HASTE()
    {
        if (boton_haste2 == false)
        {
            boton_haste2 = true;
            player.haste_spell();
            //turno_ataque();
            bandera = false;
            contador = 0;
            if (contador2 == 1) { turno = false; }

            
            

        }
        else
        {
            info_combate.text = "ya has incrementado tu velocidad";
            


        }
    }
        

    

    public void fase_jugador()
    {
        boton_de_ataque = false;
        if (boton_de_defensa == true)
        {
            int def2 = player.comandos_defensa(false);
            info_combate.text = "tu defensa ahora tiene un valor de " + def2;
        }
        boton_de_defensa = false;
        boton_ataque.SetActive(true);
        boton_defensa.SetActive(true);
        boton_objetos.SetActive(true);
    }

    public void fase_enemigo()
    {
        
        boton_ataque.SetActive(false);
        boton_defensa.SetActive(false);
        boton_objetos.SetActive(false);
        int daño2 = player.takenDmg(enemy.attack());
        vida_actual.text = player.vida() + "";
        bandera = true;
        
    }


    
    void Update()
    {

        int vel_p = player.velocidad();
        int vel_e = enemy.velocidad();
        int dif = vel_p - vel_e;
        if (player.vida() <= 0 || enemy.vida() <= 0)
            {
            info_combate.text="Juego terminado";
            }
        else {

            if ((dif > 0 || contador ==1) && turno==true)
            {
                
                bandera = true;
                if (dif > 0)
                {
                    contador2 = 1;
                }
                else
                {
                    contador2 = 0;
                }
                
                
                
            }
            else
            {
                
                bandera = false;
                
            }


            if (bandera == true)
                {
                    fase_jugador();
                    
                }
            else
            {
                    fase_enemigo();
                contador = 1;
                turno = true;

                
                
                    
                
                
            }
           

           
           
        }
    }
 }

