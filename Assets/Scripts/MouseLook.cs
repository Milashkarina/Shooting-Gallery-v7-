using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MouseLook : MonoBehaviour
{   //Переменная движения влево и вправо
    public Transform playerBody;
    //Чуствительность мышки
    public float mouseSensitivity=100f;
    //Переменная для X
    float XRotation=0f;
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }
    void Update()
    {   // Передвижение по осям (отслеживание)
        //Умножаем на mouseSensitivity и Time.deltaTime для плавного перемещения
        float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;
        
        XRotation-=mouseY;
        //Ограничение движения с помощью метода Clamp
        XRotation=Mathf.Clamp(XRotation,-90f,90f);
        //Получение вектора (передача вращения)
        //Quaternion-отвечает за вращение
        transform.localRotation=Quaternion.Euler(XRotation,0f,0f);
        playerBody.Rotate(Vector3.up*mouseX);
    }
}
