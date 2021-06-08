using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        dirtEffect = GameObject.Find("FX_DirtSplatter").GetComponent<
        ParticleSystem>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier; 
        
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
            isOnGround = false;
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //yere degdiginde isOnGround true
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
            //if (gameOver == true && Input.GetKeyDown(KeyCode.Space))
            //{
                
            //    SceneManager.LoadScene("Prototype 3");
            //}
                
        }
    }   

}
