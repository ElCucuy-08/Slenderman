using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Mouse : MonoBehaviour
{
    public float sensitivity = 100f; // Чувствительность (можно менять в инспекторе)
    public Transform playerBody; // Ссылка на тело игрока, если камера дочерняя
    private float xRotation = 0f;

    void Start()
    {
        // Скрыть курсор и закрепить его
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Locked;
        // Загружаем сохраненное значение или используем стандартное
        sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 100f);
        // Устанавливаем значение ползунка
        // Если ползунок есть на сцене, можно его найти и установить
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Вращение по вертикали (камера вверх/вниз)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ограничиваем обзор
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Вращение по горизонтали (тело влево/вправо)
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Метод для установки чувствительности извне (например, через UI)
    public void SetSensitivity(float newSensitivity)
    {
        sensitivity = newSensitivity;
        // Сохраняем настройку для будущих запусков
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        PlayerPrefs.Save();
    }
}
