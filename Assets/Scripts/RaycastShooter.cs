using System.Collections;
using UnityEngine;
//включает работу с интерфейсом
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RaycastShooter : MonoBehaviour
{//Обьявляем основые перменные
    //Переменная степени урона порожаемому обькту (public-модификатор доступа)
    public int gunDamage=1;
    //временной интервал между выстрелами
    public float fireRate=0.25f;
    //Длина луча
    public float weaponRange=50f;
    //Сила урона порожаемому обьекту
    public float hitForce=100f;
    //Ссылка на обьект (в данном случае это пустой обьекст под именем gunEnd)
    public Transform gunEnd;
    //Перменная для вывода очков игрока
    public Text txtScore;
    //Перменная для вывода лучшего результата игрока
    public Text txtBest;    
    //Приватные перменные
    //Хранение ссылки на камеру персонажа
    private Camera playerBody;
    //Хранение времени ,на протяжении которого будет отрисовываться лазер
    //new пишется потому что WaitForSeconds является экземплятом класса
    private WaitForSeconds shotDuration=new WaitForSeconds(0.07f);
    //Ссылка на аудио
    private AudioSource  gunAudio;
    //Для отрисовки лазера добавляем сслыку на компонент LineRender
    private LineRenderer laserLine; 
    //Сохраняем Время следующего выстрела
    private float nextFire;
    
     //Прописываем ссылки на необходимые компоненты
    void Start()
    {   laserLine = GetComponent<LineRenderer>();
        gunAudio=GetComponent<AudioSource>();
        playerBody=GetComponentInParent<Camera>();
        
        
    }
    //Пишем фукнционал стрельбы лазером
    void Update()
    {   //Реализация выстрела
        //Input.GetMouseButtonDown(0)("Fire1")-Проверяем нажатие левой клавиши мыши
        //&&Time.time>nextFire-проверка что игрок может выстрелить
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            //Переменная начала луча
            Vector3 rayOrigin=playerBody.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
            //Хранение точек касания луча 
            RaycastHit hit;
            // Установка начального положения для  лазера в gunEnd
             laserLine.SetPosition (0, gunEnd.position);
             //Проверка пересечения
             if (Physics.Raycast (rayOrigin, playerBody.transform.forward, out hit, weaponRange))
            {   //Установитка конечного положения для лазера
                laserLine.SetPosition (1, hit.point);
                //Является  ли цель поражаемой (в данном случае это ShootableBox)
                //hit.collider добавляется для того,чтобы GetComponent работал именно с коллайдером
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();
                //Работаем с методами  ShootableBox в RaycastShooter
                //Включаем проверку на нахождение  метода ShootableBox для утсранения ошибки 
                if (health !=null)
                {  
                    //Сила поражения
                    health.Damage (gunDamage);
                    //Получение значения очков через класс ShootableBox 
                    txtScore.text=ShootableBox.score.ToString();
                    txtBest.text=ShootableBox.score.ToString();
                    
                }
            
                
            }
            else
            {
                laserLine.SetPosition (1, rayOrigin + (playerBody.transform.forward * weaponRange));

            }



        }
        
    }
    // Воспроизведение эффектов (использоуем мтод Coroutine)
    private IEnumerator ShotEffect()
    {
        gunAudio.Play ();

       
        laserLine.enabled = true;

        
        yield return shotDuration;

       
        laserLine.enabled = false;
    }

}
