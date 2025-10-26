using UnityEngine;//���������� ��� �����
using UnityEngine.UI;//���������� ��� ������ � UI ����������

public class Papers : MonoBehaviour
{
    [SerializeField] Text textCountPaper;//����,������� ������ � ���� ����� � ����������� ������� �� �����
    [SerializeField] Text textTakePaper;//����,������� ������ � ���� �����,���������� �� ������ �������
    [SerializeField] int countPaper;//���������� ������� �� �����

    private void Start()
    {
        countPaper = GameObject.FindGameObjectsWithTag("Paper").Length;//������� ������� � ������� ����
    }

    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        textCountPaper.text = "Papers: " + countPaper;//������� �������,������� ������� �������� �� �����
    }

    private void OnTriggerStay(Collider other)//���������,��� �� ����� ������ ��������
    {
        if(other.CompareTag("Paper"))//���������,��� ��� ��� Paper
        {
            textTakePaper.gameObject.SetActive(true);//�������� ����� ��� ������� �������
            if(Input.GetKeyDown(KeyCode.F))//���� ������ ������� F
            {
                textTakePaper.gameObject.SetActive(false);//��������� ����� ��� ������� �������
                Destroy(other.gameObject);//������ ���������� ����������� �������
                countPaper--;
            }
        }
    }
    private void OnTriggerExit(Collider other)//�� ��� ������,���� ������ ����� � ���� �������� � ����� �� ����,�� �� ��������� �������
    {
        textTakePaper.gameObject.SetActive(false);//��������� ����� ��� ������� �������
    }
}
