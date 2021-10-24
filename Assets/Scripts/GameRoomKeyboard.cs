using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRoomKeyboard : MonoBehaviour
{
    string IDword = null;

    int IDIndex = -1;

    string alphaID = null;
    string alphaID2 = null;

    public InputField nickName;
    public InputField roomName;
    public InputField chatting;

    char[] IDChar = new char[30];

    public GameObject KeyboardLower;
    public GameObject KeyboardUpper;

    public GameObject LobbyPanel;
    public GameObject RoomPanel;

    public InputField input;


    public void OnClickNickName()
    {
        //�г��� �Է� ĭ ������ Ű����ui Ȱ��ȭ
        KeyboardLower.SetActive(true);
        KeyboardUpper.SetActive(false);

        IDIndex = -1;
        IDChar = new char[30];
        alphaID = null;
        IDword = null;
        input.text = null;
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
        if (RoomPanel.activeSelf)
        {
            input = chatting;
            

        }
        else if (LobbyPanel.activeSelf)
        {
            input = roomName;
            
        }
        else
        {
            input = nickName;
        }


        alphabet = KeyboardLower.activeSelf ? alphabet : alphabet.ToUpper();

        IDIndex++;
        char[] keepIDchar = alphabet.ToCharArray();
        IDChar[IDIndex] = keepIDchar[0];
        alphaID = IDChar[IDIndex].ToString();
        IDword = IDword + alphabet;

        input.text = IDword;

    }

    public void backspaceFunction()
    {
        if (IDIndex >= 0)
        {
            IDIndex--;

            alphaID2 = null;

            for (int i = 0; i < IDIndex + 1; i++)
            {
                alphaID2 = alphaID2 + IDChar[i].ToString();
            }

            IDword = alphaID2;

            input.text = IDword;
        }
    }

}