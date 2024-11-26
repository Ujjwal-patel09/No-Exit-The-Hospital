using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_UI : MonoBehaviour
{
    public GameObject Interact_Ui_Icon;

    private void Update() 
    {
        if(Player_Interaction.instance.Get_Door_Object() != null)
        {
            Show_UI();
        }else
        {
            Hide_UI();
        }
    }

    // to show and hide "Mouse Left Click" Icon Ui image //
    public void Show_UI()
    {
        Interact_Ui_Icon.SetActive(true);
    }

    public void Hide_UI()
    {
        Interact_Ui_Icon.SetActive(false);
    }
}
