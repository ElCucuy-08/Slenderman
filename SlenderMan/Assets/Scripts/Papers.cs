using UnityEngine;//���������� ��� �����
using UnityEngine.UI;//���������� ��� ������ � UI ����������
using UnityEngine.Rendering.PostProcessing;//���������� ��� ������ � PostProcessing

public class Papers : MonoBehaviour
{
    [SerializeField] Text textCountPaper;//����,������� ������ � ���� ����� � ����������� ������� �� �����
    [SerializeField] Text textTakePaper;//����,������� ������ � ���� �����,���������� �� ������ �������
    [SerializeField] int countPaper;//���������� ������� �� �����

    [SerializeField] GameObject slender;//��������� ��� ��������,��� ��������� ��� �������
    [SerializeField] PostProcessVolume effects;//����� � ����������� ������������� ���� �������
    PostProcessVolume m_Volume;
    Grain m_Grain;

    private void Start()
    {
        countPaper = GameObject.FindGameObjectsWithTag("Paper").Length;//������� ������� � ������� ����
        //����������� �������
        m_Grain=ScriptableObject.CreateInstance<Grain>();
        m_Grain.enabled.Override(true);
        m_Grain.intensity.Override(1f);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Grain);
    }

    private void Update()
    {
        //���������� ��������� �������� ������������ ���
        float DotResult = -1 * Vector3.Dot(transform.forward, slender.transform.forward);
        if(DotResult < 0.1f)
        {
            DotResult = 0.1f;
        }

        //������ �������� ���� ��������
        m_Grain.intensity.value = DotResult;
        m_Grain.size.value = DotResult * 3;
        m_Grain.lumContrib.value= DotResult;

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
