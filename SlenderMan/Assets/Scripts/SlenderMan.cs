using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//Библиотека для навигации

public class SlenderMan : MonoBehaviour
{
    NavMeshAgent agent;//Создаём навигацию(куда двигаемся)
    Transform player;//Поле в котором будет находится наш игрок(мы)
    Vector3 playerCorrectPosition = Vector3.zero;//Позиция нашего игрока,к которой будет идти слендер
    Vector3 newPos = Vector3.zero;//Новая позиция нашего слендара

    float teleportTimer = 10;//Време,через сколько слендер телепортируется

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//Находим игрока по тэгу
    }
    private void Update()
    {
        playerCorrectPosition = player.position;//Передаём позицию игрока
        playerCorrectPosition.y = transform.position.y;//Перадаём позицию слендара по оси y,чтобы тот был с нами на одном уровне
        transform.LookAt(playerCorrectPosition);//Поворачиваем нашего слендара к нам лицом

        if (Vector3.Distance(playerCorrectPosition, transform.position) > 1.5)//Проверяем дистанцию до игрока
        {
            transform.position = Vector3.MoveTowards(transform.position, playerCorrectPosition, Time.deltaTime * 8);
        }
        teleportTimer -= Time.deltaTime;
        if (teleportTimer < 0)
        {
            teleportTimer = Random.Range(15, 30);
            Teleport();
        }
    }
    private void FixedUpdate()
    {
        //Узнаём дистанцию между нами и слендером
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance > 6)//Если дистанция больше 3,то не атакуем,а преследуем
        {
            GetComponent<Animator>().SetBool("Attack", false);//Отключаем анимацию атаки
        }
        else
        {
            //Поворачиваем слендара в сторону игрока,чтобы атаковать
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            GetComponent<Animator>().SetBool("Attack", true);//Включаем анимацию атаки
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//Проверяем,что это тэг Player
        {
            Destroy(other.gameObject);//Внешне уничтожаем нашего игрока
        }
    }
    void Teleport()
    {
        newPos = playerCorrectPosition;
        newPos.y = transform.position.y;
        do
        {
            newPos.x += Random.Range(-80, 80);
            newPos.z += Random.Range(-80, 80);
        }
        while (Vector3.Distance(newPos, playerCorrectPosition) < 20);
        transform.position = newPos;
    }
}
