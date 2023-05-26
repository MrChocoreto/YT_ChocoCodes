using UnityEngine;

public class NKrypt : MonoBehaviour
{

    #region Variables

    [TextArea, SerializeField] string Phrase = default;
    [TextArea, SerializeField] string CyPhrase = default;
    [TextArea, SerializeField] string UnCyPhrase = default;
    [SerializeField] int Spin = default;
    

    #endregion



    #region My_Methods

    //Text_To_ASCII
    [ContextMenu("ASCII")]
    public void TTA()
    {
        CyPhrase = default;
        int ASCII = default;
        for (int i = 0; i < Phrase.Length; i++)
        {
            ASCII = Phrase[i];

            //UpperCase
            if (ASCII >= 65 && ASCII <= 90)
            {
                CyPhrase += CCC(ASCII,90,0);
            }
            //LowerCase
            else if (ASCII >= 97 && ASCII <= 122)
            {
                CyPhrase += CCC(ASCII,122, 1);
            }
            else
            {
                CyPhrase += Phrase[i];
            }

        }

    }

    //ASCII_To_Text
    [ContextMenu("Text")]
    public void ATT()
    {
        UnCyPhrase = default;
        int ASCII = default;
        for (int i = 0; i < CyPhrase.Length; i++)
        {
            ASCII = CyPhrase[i];

            //UpperCase
            if (ASCII >= 65 && ASCII <= 90)
            {
                UnCyPhrase += ICCC(ASCII, 90, 0);
            }
            //LowerCase
            else if (ASCII >= 97 && ASCII <= 122)
            {
                UnCyPhrase += ICCC(ASCII, 122, 1);
            }
            else
            {
                UnCyPhrase += CyPhrase[i];
            }

        }


    }


    //Convert Cesar's Cripto
    string CCC(int ASCII,int limit, byte Cases)
    {
        int Delta = default;
        int PosIni= default;
        int Counter = 0;
        char res;
        
        switch (Cases)
        {
            case 0: 
                PosIni = 26 - (limit - ASCII);
                break;
            case 1:
                PosIni = 26 - (limit - ASCII);
                break;
        }



        for (int i = PosIni; i < 27; i++)
        {
            if (Counter != Spin && i == 26)
            {
                i = 0;
            }
            else if (Counter==Spin)
            {
                if (Cases==0)
                {
                    Delta = 64 + i; 
                }
                else
                {
                    Delta = 96 + i;
                }
                i = 27;
            }
            Counter++;
            if (Counter != Spin && i == 26)
            {
                i = 0;
            }
            
        }

        res = (char)Delta;
        return res.ToString();
    }

    //Inverse Convert Cesar's Cripto
    string ICCC(int ASCII, int limit, byte Cases)
    {
        int Delta = default;
        int PosIni = default;
        int Counter = 0;
        char res;

        switch (Cases)
        {
            case 0:
                PosIni = (26 - (limit - ASCII));
                break;
            case 1:
                PosIni = (26 - (limit - ASCII));
                break;
        }


        for (int i = PosIni; i > -1; i--)
        {
            
            if (Counter != Spin && i == 0)
            {
                i = 26;
            }
            else if (Counter == Spin)
            {
                
                if (Cases == 0)
                {
                    Delta = 64 + i;
                    Debug.Log(Delta);

                }
                else
                {
                    Delta = 96 + i;
                }
                i = -1;
            }

            Counter++;
        }

        res = (char)Delta;
        return res.ToString();
    }



    #endregion


}

