
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

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
    public GameObject estatuillamodel;
    public float timetoenemydeathboixactivation;
    public float timeforexitdoortoopen;
    public bool timerondeathbox = false;
    public bool timeronexitdoor = false;
    public bool deathboxon = false;

    Animator animator;

    [SerializeField] private PostProcessVolume postprocessvolume;
    private AmbientOcclusion ambientocclusion;
    public GameObject exitdoor;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        dialogueUI.SetActive(false);
        enemy.GetComponent<AgentScript>().enabled = false;
        postprocessvolume.profile.TryGetSettings(out ambientocclusion);
        ambientocclusion.active = false;
        estatuillamodel.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        if (estatuilla == true)
        {
            dialogueUI.SetActive(false);//esto lo hice pq se activaba mientras te corria el personaje

            animator.Play("run");
        }
        else
        {
            animator.Play("wave");
        }

        if (Input.GetKeyDown(KeyCode.E) && hasTalked == false)
        {
            NextFrase();
        }

        terminarmision();
        if (timerondeathbox == true)
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
        if (timeronexitdoor == true)
        {
           
            if (timeforexitdoortoopen > 0)
            {
                timeforexitdoortoopen -= Time.deltaTime;
            }
            else
            {
                enemy.GetComponent<AgentScript>().enabled = true;
                Destroy(exitdoor);
            }

        }
        if (hasTalked == true)
        {
            estatuillamodel.SetActive(true);
            dialogueUI.SetActive(false); //esto lo hice pq se activaba mientras te corria el personaje

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
        if (other.gameObject.CompareTag("WinPlane")) //me quedé aca, que si tocas la plane... cambia a la win scene pero no llegue a terminar hoy.
        {
            Debug.Log("hhh");
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
           
            timerondeathbox = true;
            timeronexitdoor = true;
            ambientocclusion.active = true;
        }
    }
    
}


