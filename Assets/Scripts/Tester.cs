using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Conversation convo;
    public bool dialoguePlayed = false;
    public GameObject hiddenMessage;
    public PlayerMovement pM;

    

    void Awake()
    {
       // player.GetComponent<PlayerMovement>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        hiddenMessage.SetActive(true);

        //if(!dialoguePlayed)
        // {
        //StartConvo();
        //dialoguePlayed = true;
        // }
        pM.dialogueCheck = true;

}

    private void OnTriggerExit(Collider collision)
    {
        hiddenMessage.SetActive(false);
        pM.dialogueCheck = false;
    }
    
    public void StartConvo()
    {
        DialogueManager.StartConversation(convo);
    }
}
