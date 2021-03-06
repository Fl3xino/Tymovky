using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public enum DoorType
    {
        left, right, top, bottom, trapdoor
    }

    public DoorType doorType;
    public GameObject doorCollider;
    private GameObject player;
    private float widthOffset = 2f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (doorType)
            {
                case DoorType.bottom:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y - widthOffset);
                    break;
                case DoorType.left:
                    player.transform.position = new Vector2(transform.position.x - widthOffset, transform.position.y);
                    break;
                case DoorType.right:
                    player.transform.position = new Vector2(transform.position.x + widthOffset, transform.position.y);
                    break;
                case DoorType.top:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y + widthOffset);
                    break;
                case DoorType.trapdoor:
                    SceneManager.LoadScene("Menu");
                    break;
            }
        }
    }
}
