using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//���������� ��� ���������

public class SlenderMan : MonoBehaviour
{
    NavMeshAgent agent;//������ ���������(���� ���������)
    Transform player;//���� � ������� ����� ��������� ��� �����(��)
    Vector3 playerCorrectPosition = Vector3.zero;//������� ������ ������,� ������� ����� ���� �������
    Vector3 newPos = Vector3.zero;//����� ������� ������ ��������

    float teleportTimer = 10;//�����,����� ������� ������� ���������������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//������� ������ �� ����
    }
    private void Update()
    {
        playerCorrectPosition = player.position;//������� ������� ������
        playerCorrectPosition.y = transform.position.y;//������� ������� �������� �� ��� y,����� ��� ��� � ���� �� ����� ������
        transform.LookAt(playerCorrectPosition);//������������ ������ �������� � ��� �����

        if (Vector3.Distance(playerCorrectPosition, transform.position) > 1.5)//��������� ��������� �� ������
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
        //����� ��������� ����� ���� � ���������
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance > 6)//���� ��������� ������ 3,�� �� �������,� ����������
        {
            GetComponent<Animator>().SetBool("Attack", false);//��������� �������� �����
        }
        else
        {
            //������������ �������� � ������� ������,����� ���������
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            GetComponent<Animator>().SetBool("Attack", true);//�������� �������� �����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//���������,��� ��� ��� Player
        {
            Destroy(other.gameObject);//������ ���������� ������ ������
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
