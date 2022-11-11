using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData : MonoBehaviour
{
    [CreateAssetMenu(fileName = "NPCdata", menuName = "Crear npc data")]
    public class NPCdata : ScriptableObject
    {
        public string[] dialoguelines;
        public bool misionempezada = false;
        public int contadorcomponentes = 0;

    }
}
