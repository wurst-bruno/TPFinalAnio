
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI textoDelDialogo, textoBoton;
    [SerializeField] string[] frasesDialogo;
    [SerializeField] int posicionFrase;
    [SerializeField] bool hasTalked;
    public static bool misionempezadadialogue;
    public static bool estatuilla=false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasTalked == false)
        {
            NextFrase();
        }
        terminarmision();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            //frasesDialogo = other.gameObject.GetComponent<NPCDIALOGUE>().data.dialoguelines;


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
        if (other.gameObject.CompareTag("NPC"))
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
        }
    }
}


