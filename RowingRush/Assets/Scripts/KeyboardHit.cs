using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardHit : MonoBehaviour
{
    string IDword = null;
    string PWword = null;

    int IDIndex = -1;
    int PWIndex = -1;

    bool isIDInput = false;
    bool isPWInput = false;

    string alphaID = null;
    string alphaID2 = null;

    string alphaPW = null;
    string alphaPW2 = null;

    public InputField IDtext;
    public InputField PWtext;

    public GameObject ToggleBtnShow;
    public GameObject ToggleBtnHide;

    char[] IDChar = new char[30];
    char[] PWChar = new char[30];

    public GameObject KeyboardLower;
    public GameObject KeyboardUpper;

    public void OnClickID()
    {
        //ID �Է� ĭ ������ Ű����ui Ȱ��ȭ��Ű�� ID �Է� ĭ���� �Է� �ޱ�
        KeyboardLower.SetActive(true);
        KeyboardUpper.SetActive(false);
        isIDInput = true;
        isPWInput = false;
    }

    public void OnClickPW()
    {
        //PW �Է� ĭ ������ Ű����ui Ȱ��ȭ��Ű�� PW �Է� ĭ���� �Է� �ޱ�
        KeyboardLower.SetActive(true);
        KeyboardUpper.SetActive(false);
        isPWInput = true;
        isIDInput = false;
    }

    public void OnClickEnter()
    {
        //enter ������ Ű����ui ��Ȱ��ȭ
        KeyboardLower.SetActive(false);
        KeyboardUpper.SetActive(false);
    }

    public void OnClickUpper()
    {
        //���� ȭ��ǥ ��ư ������ �빮�ڷ� ��ȯ

        //�ҹ��� Ű���尡 Ȱ��ȭ�Ǿ� ������ 1, �빮�� Ű���尡 Ȱ��ȭ�Ǿ� ������ 0�� ��ȯ
        bool isKeyboardType = KeyboardLower.activeSelf == true;

        //1�̸� �빮�� Ű���� Ȱ��ȭ, 0�̸� �ҹ��� Ű���� Ȱ��ȭ��Ű��
        KeyboardLower.SetActive(!isKeyboardType);
        KeyboardUpper.SetActive(isKeyboardType);

    }

    public void alphabetFunction(string alphabet)
    {
        alphabet = KeyboardLower.activeSelf ? alphabet : alphabet.ToUpper();

        if (isIDInput)
        {
            IDIndex++;
            char[] keepIDchar = alphabet.ToCharArray();
            IDChar [IDIndex] = keepIDchar[0];
            alphaID = IDChar [IDIndex].ToString();
            IDword = IDword + alphabet;
            IDtext.text = IDword;
        }

        if (isPWInput)
        {
            PWIndex++;
            char[] keepPWchar = alphabet.ToCharArray();
            PWChar[PWIndex] = keepPWchar[0];
            alphaPW = PWChar [PWIndex].ToString();
            PWword = PWword + alphabet;
            PWtext.text = PWword;
        }

    }

    public void backspaceFunction()
    {
        if (isIDInput)
        {
            if (IDIndex >= 0)
            {
                IDIndex--;

                alphaID2 = null;
                
                for(int i=0; i<IDIndex+1; i++)
                {
                    alphaID2 = alphaID2 + IDChar[i].ToString();
                }

                IDword = alphaID2;
                IDtext.text = IDword;
                
            }
        }

        if (isPWInput)
        {
            if (PWIndex >= 0)
            {
                PWIndex--;

                alphaPW2 = null;

                for (int i = 0; i < PWIndex + 1; i++)
                {
                    alphaPW2 = alphaPW2 + PWChar[i].ToString();
                }

                PWword = alphaPW2;
                PWtext.text = PWword;
            }
        }

    }

    public void TooglePasswordVisablilty()
   
    {
        bool isCurrentlyPassword = PWtext.contentType == InputField.ContentType.Password;

        if (isCurrentlyPassword)
        {
            ToggleBtnShow.SetActive(true);
            ToggleBtnHide.SetActive(false);
        }
        else
        {
            ToggleBtnShow.SetActive(false);
            ToggleBtnHide.SetActive(true);
        }

        PWtext.contentType = isCurrentlyPassword ? InputField.ContentType.Standard : InputField.ContentType.Password;

        PWtext.ForceLabelUpdate();
    }


}