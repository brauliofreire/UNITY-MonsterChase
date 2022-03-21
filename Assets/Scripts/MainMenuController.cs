using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        var btName = EventSystem.current.currentSelectedGameObject.name;
        if (btName.ToUpper().Equals("BT_PLAYER_0"))
            GameManager.instance.playerIndex = 0;
        if (btName.ToUpper().Equals("BT_PLAYER_1"))
            GameManager.instance.playerIndex = 1;

        SceneManager.LoadScene("Gameplay");
    }
}
