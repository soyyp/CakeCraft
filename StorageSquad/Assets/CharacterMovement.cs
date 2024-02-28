using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public GameObject character;
    private SpriteRenderer m_SpriteRenderer;
    private bool faceLeft;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        faceLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            if ((double) character.transform.position.x > -5) {
                if (faceLeft == false) {
                    m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
                    faceLeft = true;
                }
                character.transform.Translate(-1,0,0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            if ((double) character.transform.position.x < 5) {
                if (faceLeft == true) {
                    m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
                    faceLeft = false;
                }
                character.transform.Translate(1,0,0);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            if ((double) character.transform.position.y < 3) {
                character.transform.Translate(0,1,0);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            if ((double) character.transform.position.y > -3) {
                character.transform.Translate(0,-1,0);
            }
        }
    }
}
