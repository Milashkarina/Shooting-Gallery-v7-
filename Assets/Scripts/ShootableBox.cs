using UnityEngine;
using System.Collections;



public class ShootableBox : MonoBehaviour {

    //Текущее здоровье данного обьекта (сколько раз должны выстрелить чтобы поразить обьект)
    public int currentHealth = 1;
    //Переменная для подсчета очков
    //Благодаря static мы считаем очки для всех обьектов
    public static int score;
    public static int best;
    //Метод поражения цели (он принимает параметр целого числа.Данное значение вычитается из параметра здоровья (currentHealth ) )
    public void Damage(int damageAmount)
    {
        //Вычитание жизней 
        currentHealth -= damageAmount;
        //Прибавление 1 балла за вычетание жизней
        score++;
        best=score;
        

        //Условие  проверки уровня здоровья
        if (currentHealth <= 0) 
        {
            //Если он меньше нуля,то цель скрывается
            gameObject.SetActive (false);
            //Прибавление очков за уничтожение цели
            score+=5;
            //Выввод в консоль 
            Debug.Log(score);
            Debug.Log(best);
        }

        
          
    }

}