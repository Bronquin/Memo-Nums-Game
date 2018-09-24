using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed,force;
    public Text randNumText, scoreText;
    private string randNum; 
    private int currentDigitSpot, score;
        
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randNum=generateRandomNumber(5);
        currentDigitSpot = 0;
        score = 0;
        setScoreText();
    }

    void FixedUpdate()
    {
        float moveHori = -Input.GetAxis("Horizontal");
        float moveVert = -Input.GetAxis("Vertical");
        float jump = 0;
        if (Input.GetKeyDown("space")) //also check if sphere transform is 0.5
            jump = force;
        Vector3 movement = new Vector3(moveHori*speed, jump, moveVert*speed);

        rb.AddForce(movement);
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().endGame();
        }
    }

    string generateRandomNumber(int numDigits)
    {    
        string s = "";
        for(int z=0; z<numDigits; z++)
        {
            int temp = Random.Range(1, 10);
            s = s + temp;
        }
        randNumText.text = s;
        return s;
    }

    void OnCollisionExit(Collision other)
    {
        string lookFor = "Tile"+randNum.Substring(currentDigitSpot,1);
        if (other.gameObject.tag == lookFor)
        {
            Debug.Log("Correct " + randNum.Substring(currentDigitSpot, 1));
            randNumText.text = "";
            currentDigitSpot++;
            
            if (currentDigitSpot >= 5)
            {
                randNum = generateRandomNumber(5);
                currentDigitSpot = 0;
                score++;
                setScoreText();
            }
        }
        else if (other.gameObject.tag !="Untagged")
        {
            Debug.Log("Wrong " + other.gameObject.tag);
            currentDigitSpot = 0;
            randNumText.text = randNum;
        }
       
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSecondsRealtime(2);
    }

}
    //add sound effects
    //disappear text when starting sequence
    //if fall off, only want the object to reset position