
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI textoDelDialogo, textoBoton;
    [SerializeField] string[] frasesDialogo;
    [SerializeField] int posicionFrase;
    [SerializeField] bool hasTalked;
    public static bool misionempezadadialogue;
    public bool estatuilla=false;
    public static bool comenzaraseguirplayer = false;
    public GameObject enemy;
    public GameObject player;
    public float timetoenemydeathboixactivation;
    public bool timeron = false;
    public bool deathboxon = false;
    [SerializeField] private PostProcessVolume postprocessvolume;
    private AmbientOcclusion ambientocclusion;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        enemy.GetComponent<AgentScript>().enabled = false;
        postprocessvolume.profile.TryGetSettings(out ambientocclusion);
        ambientocclusion.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasTalked == false)
        {
            NextFrase();
        }
        terminarmision();
        if (timeron == true)
        {
            if (timetoenemydeathboixactivation > 0)
            {
                timetoenemydeathboixactivation -= Time.deltaTime;
            }
            else
            {
                enemy.GetComponent<AgentScript>().enabled = true;
                deathboxon = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // frasesDialogo = other.gameObject.GetComponent<NPCDIALOGUE>().data.dialoguelines;


            dialogueUI.SetActive(true);

            if (!hasTalked)
            {
                //al entrar activa la UI de dialogo
                textoDelDialogo.text = "Hola estudiante";
            }

            else
            {
                textoDelDialogo.text = "Ve a buscar las cosas!";

            }
            if (deathboxon==true)
            {
                
                Destroy(player);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("estatuilla"))
        {
            estatuilla = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //al entrar desactiva la UI de dialogo
            dialogueUI.SetActive(false);
        }
    }

    public void NextFrase()
    {



        if (posicionFrase < frasesDialogo.Length)
        {
            textoDelDialogo.text = frasesDialogo[posicionFrase];
            posicionFrase++;

            if (posicionFrase == frasesDialogo.Length)
            {
                textoBoton.text = "Cerrar";
            }
        }

        else
        {
            dialogueUI.SetActive(false);
            hasTalked = true;
            misionempezadadialogue = true;
        }

    }
    void terminarmision()
    {
        if (estatuilla == true)
        {
            misionempezadadialogue = false;
           
            timeron = true;
            ambientocclusion.active = true;
        }
    }
   
}


