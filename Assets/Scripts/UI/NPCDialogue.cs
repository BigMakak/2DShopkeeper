using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    [SerializeField] private GameObject UIDialogueContainer;

    [SerializeField] private float timeOpen = 10f;
    
    public void AlterDialogue() 
    {
        if(UIDialogueContainer == null) 
        {
            Debug.LogWarning("No dialogue container, no dialogue will be shown for this npc");
            return;
        }

        // Toggles the dialogue container for a speficic NPC
        UIDialogueContainer.gameObject.SetActive(!UIDialogueContainer.gameObject.activeSelf);
        
        CancelInvoke();
        // After a certain time, close the dialogue
        Invoke("CloseDialogue",timeOpen);
    }

    private void CloseDialogue() 
    {
        UIDialogueContainer.gameObject.SetActive(false);
    }
}
