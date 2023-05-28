using UnityEngine;

public class Choco_Coding : MonoBehaviour{

    [TextArea] public string Frase;
    [TextArea] public string FraseEncriptada;
    [TextArea] public string FraseDesEncriptada;


    
    
    [ContextMenu("Encriptar")]
    void Encriptar()
    {
        FraseEncriptada = default;
        Frase = Frase.ToLower();

        int ASCII = 0;

        for (int i = 0; i < Frase.Length; i++)
        {
            FraseEncriptada = FraseEncriptada + Binario(ASCII);
            ASCII = 0;
        }
    }

    string Binario(int ASCII)
    {
        string Resultado = default;
        int Ciclo = 0;
        int ResultadoBinario = 0;

        while (Ciclo < 8)
        {
            Ciclo++;
            ResultadoBinario = ASCII % 2;
            ASCII /= 2;
            Resultado = ResultadoBinario.ToString() + Resultado;
        }

        return Resultado;
    }




    [ContextMenu("DesEcriptar")]
    void DesEncriptar()
    {
        FraseDesEncriptada = default;

        string NumBinario = default;
        int Contador = 0;
        for (int i = 0; i < FraseEncriptada.Length; i++)
        {
            NumBinario = NumBinario + FraseEncriptada[i];
            Contador++;
            if (Contador==8)
            {
                Contador = 0;
                FraseDesEncriptada = FraseDesEncriptada + ObtenerLetras(NumBinario);
                NumBinario = default;
            }
        }

    }

    char ObtenerLetras(string Binario)
    {
        char Resultado = default;
        int Bit = 0;
        int ASCII = 0;

        for (int i = 0; i < Binario.Length; i++)
        {
            Bit = int.Parse(Binario[i].ToString());

            if (Bit == 1)
            {
                switch (i)
                {
                    case 0:
                        ASCII += 128;
                        break;
                    case 1:
                        ASCII += 64;
                        break;
                    case 2:
                        ASCII += 32;
                        break;
                    case 3:
                        ASCII += 16;
                        break;
                    case 4:
                        ASCII += 8;
                        break;
                    case 5:
                        ASCII += 4;
                        break;
                    case 6:
                        ASCII += 2;
                        break;
                    case 7:
                        ASCII += 1;
                        break;
                }
            }
        }

        ASCII = ASCII / 2;
        Resultado = (char)ASCII;

        return Resultado;
    }

}