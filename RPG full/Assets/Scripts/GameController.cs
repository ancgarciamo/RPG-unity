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
    public bool bandera =true;
    public bool boton_de_ataque =false;
    Character player = new Character(50000, 20, 100, 100, 100, 100, 30);
    Character enemy = new Character(2000, 10, 200, 50, 10, 0, 20);

    public void AtacarComando()
    {
        boton_de_ataque = true;
        boton_ataque.SetActive(false);
        int daño1 = enemy.takenDmg(player.attack());
        info_combate.text = "le quitastes  " + daño1 + " puntos de vida al enemigo este ahora tiene " + enemy.vida() + "puntos de vida";
        bandera = false;
    }

    void Start()
    {
        
        vida_actual.text = player.vida()+"";
        vida_maxima.text = player.vida() + " / ";
        boton_atras.SetActive(false);
    }

    
    void Update()
    {
        

        if (player.vida() <= 0 || enemy.vida() <= 0)
            {
            info_combate.text="Juego terminado";
            }
        else { 
           if (bandera == true)
            {
            boton_de_ataque = false;
                boton_ataque.SetActive(true);
                boton_defensa.SetActive(true);
                boton_objetos.SetActive(true);
                
                    
                
            }
            else
            {
                
                boton_ataque.SetActive(false);
                boton_defensa.SetActive(false);
                boton_objetos.SetActive(false);
                int daño2 = player.takenDmg(enemy.attack());
                vida_actual.text = player.vida() + "";
                
                bandera = true;
            }
        }



    }
    }

