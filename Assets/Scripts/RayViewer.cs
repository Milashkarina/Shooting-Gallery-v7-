using UnityEngine;
using System.Collections;
//Данный код мы добавляем для проверки коррректности работы лазера в режиме Scene
public class RayViewerComplete : MonoBehaviour {
    //длина луча Raycast-дальномть выстрела
    public float weaponRange = 50f;                       
    //ссылка на камеру персонажа от первого лица (отсюда будет выпускаться Raycast)
    private Camera playerBody;                              

    void Start () 
    {
        
        playerBody = GetComponentInParent<Camera>();
    }


    void Update () 
    {
       //Отрисовка луча в зависимости от положения камеры
        Vector3 rayOrigin = playerBody.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        //Рисуем луч  в режиме отладки
        Debug.DrawRay(rayOrigin, playerBody.transform.forward * weaponRange, Color.red);
    }
}