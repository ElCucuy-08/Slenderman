using UnityEngine;//Библиотека для ЮНИТИ
using UnityEngine.UI;//Библиотека для работы с UI элементами

public class Papers : MonoBehaviour
{
    [SerializeField] Text textCountPaper;//Поле,которое хранит в себе текст с количеством листков на карта
    [SerializeField] Text textTakePaper;//Поле,которое хранит в себе текст,отвечающий за подбор записок
    [SerializeField] int countPaper;//Количество записок на карте

    private void Start()
    {
        countPaper = GameObject.FindGameObjectsWithTag("Paper").Length;//Находим записки с помощью тэга
    }

    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        textCountPaper.text = "Papers: " + countPaper;//выводим текстом,сколько записок осталось на карте
    }

    private void OnTriggerStay(Collider other)//Проверяем,что мы зашли внутрь триггера
    {
        if(other.CompareTag("Paper"))//Проверяем,что это тэг Paper
        {
            textTakePaper.gameObject.SetActive(true);//Включаем текст для подбора записок
            if(Input.GetKeyDown(KeyCode.F))//Если нажата клавиша F
            {
                textTakePaper.gameObject.SetActive(false);//Выключаем текст для подбора записок
                Destroy(other.gameObject);//Внешне уничтожаем подобранную записку
                countPaper--;
            }
        }
    }
    private void OnTriggerExit(Collider other)//На тот случай,если просто вошли в зону триггера и вышли из него,но не подобрали записку
    {
        textTakePaper.gameObject.SetActive(false);//Выключаем текст для подбора записок
    }
}
