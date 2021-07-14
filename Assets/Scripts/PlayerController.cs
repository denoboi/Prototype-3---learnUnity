using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem particleExplosion;
    public ParticleSystem dirtEffect;
    public AudioClip jumpAudio;
    public AudioClip crashAudio;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver;
    public bool doubleJumpUsed = false;

    public BoxCollider playerCollider;
    float m_ScaleX, m_ScaleY, m_ScaleZ;
    public Slider m_SliderX, m_SliderY, m_SliderZ;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        dirtEffect = GameObject.Find("FX_DirtSplatter").GetComponent<
        ParticleSystem>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

        playerCollider = GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //game over == false ile ayni 
        {
            playerAudio.PlayOneShot(jumpAudio);
            dirtEffect.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            doubleJumpUsed = false;
            isOnGround = false;


        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJumpUsed && !gameOver)
        {
            doubleJumpUsed = true;
            playerAudio.PlayOneShot(jumpAudio);
            dirtEffect.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isOnGround = false;
            
            

        }
       




    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver) //yere degdiginde isOnGround true ve dirt effecti durdurmak icin.
        {
            isOnGround = true;
            dirtEffect.Play();

        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("GameOver");
            gameOver = true;
            particleExplosion.Play(); 
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtEffect.Stop();
            playerAudio.PlayOneShot(crashAudio);

            

            //after collision, collider changes to prevent bugs
            playerCollider.center = new Vector3(0, 1.5f, -3);


            //if (gameOver == true && Input.GetKeyDown(KeyCode.Space))
            //{
                
            //    SceneManager.LoadScene("Prototype 3");
            //}
                
        }
    }   

    

}
