using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers

public class XPClickTest : MonoBehaviour
{
    /*
        //Code from tutorial
        [SerializeField] private int bonus = 10;

        private void OnMouseDown()
        {
            GameManager.Instance.CurrentPlayer.AddXp(bonus);
            Destroy(gameObject);
        }
    */

    private void OnMouseDown()
    {
        //This should pull up a menu about the track
        //GetComponent<Text>().color = Color.yellow; // Changes the colour of the text
        Destroy(gameObject);
    }


}
