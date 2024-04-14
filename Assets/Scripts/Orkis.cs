using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OblakControls;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.UI;

public class Orkis : MonoBehaviour
{
    public CharacterController orkiController;
    public bool groundedOrki;
    public bool isMove;
    public float timer = 0f;
    public int hitCounter = 0;
    public Image imgHB;
    public int damage = 5;
    public float health = 100.0f;
    public TextMeshPro textMeshPro;
    public GameObject Orki, Player; 
    [Header("Orki settings")]
    public float orkiSpeed = 1.7f;

    public Vector3 orkiVelocity;
    public float target;

    public void Awake()
    {
        Orki.GetComponent<Renderer>().material.color = new Color(0.2f, 0.4f, 0.5f);
        Orki.transform.position = new Vector3 (916.84f, 15.36f, 627.32f);
    }
    // Start is called before the first frame update
    public void Start()
    {
        //Orki.SetActive(true);
        
        Orki.layer = LayerMask.NameToLayer("Ignore Raycast");
        Orki.name = "Orki";
        Orki.tag = "Orkiboy";
        Ray rayOrki = new Ray(transform.position, transform.forward);
        orkiController = gameObject.AddComponent<CharacterController>();
        isMove = true;
        textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    public void Update()
    {
        groundedOrki = orkiController.isGrounded;
        transform.Rotate(Vector3.up * 25.0f * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.back * Time.deltaTime, Space.Self);
        //orkiController.Move(orkiVelocity * Time.deltaTime);

        // 2 lines below - draw ray
        Vector3 forwar = Orki.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(Orki.transform.position, forwar * 10, Color.green);
        
        RaycastHit hitOrki; 
            
        if(Physics.Raycast(transform.position, transform.forward, out hitOrki, 20) && hitOrki.collider.gameObject.tag == "Player")
        {     
            Player.GetComponent<Renderer>().material.color = Color.red;
            hitCounter ++;
            //print(hitCounter);
        }
        
        
        // timer += Time.deltaTime;
        // if(timer >= 7f && timer <= 8f)
        //     {
        //         Player.GetComponent<Renderer>().material.color = Color.white;   
        //         timer = 0f;
        //     }
        //     timer ++;        
    }
    void OnGUI()
        {   
            if(imgHB.fillAmount == 0)
            {
                print("Game Over");
            }

            if(hitCounter > 0 && hitCounter <= 120)
            {
                Player.GetComponent<Renderer>().material.color = Color.grey;
                imgHB.fillAmount = 0.8f;
                // health = health - imgHB.fillAmount;
            }

            if(hitCounter >= 121 && hitCounter <= 241)
            {
                Player.GetComponent<Renderer>().material.color = Color.yellow;
                imgHB.fillAmount = 0.6f;//imgHB.fillAmount - (damage * 0.000001f);
                //health = health - imgHB.fillAmount;
            }
            if(hitCounter >= 242 && hitCounter <= 320)
            {
                Player.GetComponent<Renderer>().material.color = Color.green;//new Color(0.0f, 0.9f, 0.9f);
                Font font = (Font)Resources.Load("Josefin_Sans/JosefinSans-Italic-VariableFont_wght") as Font;
                var lab = "Dark is here!";
                //lab.font = font;
                GUIStyle labelStyle = new GUIStyle();
                labelStyle.fontSize = 111;
                labelStyle.normal.textColor = new Color(0.9f, 0.7f, 0.5f);
                labelStyle.fontStyle = FontStyle.Bold;
                //Font labelFont = (Font)Resources.Load("Assets/Josefin_Sans", typeof(Font));
                labelStyle.font = font;
                GUI.Label(new Rect(20, 20, 200, 200), lab, labelStyle); 
                imgHB.fillAmount = 0.4f;
                //health = health - imgHB.fillAmount; 
            }
            if(hitCounter >= 321)
            {
                Player.GetComponent<Renderer>().material.color = Color.black;
                imgHB.fillAmount = 0;
                //health = health - imgHB.fillAmount;
            }
                
        }

    
}
