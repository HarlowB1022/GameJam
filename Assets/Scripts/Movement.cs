using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
    public event EventHandler OnQPressed;
    public GameObject blue;
    public GameObject pink;
    Rigidbody2D rb1;
    Rigidbody2D rb2;
    CharacterController2D controller1;
    CharacterController2D controller2;
    public float speed;
    float inputX = 0f;
    bool switchPlayer = true;
    bool jmp = false;

    void Start(){
        OnQPressed += QPressed;
        rb1 = blue.GetComponent<Rigidbody2D>();
        rb2 = pink.GetComponent<Rigidbody2D>();
    
        controller1 = blue.GetComponent<CharacterController2D>();
        controller2 = pink.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)) OnQPressed?.Invoke(this, EventArgs.Empty);
        inputX = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")) jmp = true;
    }
    void FixedUpdate(){
        if(switchPlayer) { 
            controller1.Move(inputX * Time.fixedDeltaTime * speed, false, jmp);
            }
        else{ 
            controller2.Move(inputX * Time.fixedDeltaTime * speed, false, jmp);
        }
        jmp = false;
    }
    void QPressed(object sender, EventArgs ea){
        switchPlayer = !switchPlayer;
    }
}
