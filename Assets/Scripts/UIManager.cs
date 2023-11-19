using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;



internal class UIManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Public Fields
    
    public TextMeshProUGUI numberText1, numberText2, numberText3;

    public GameManager gameManager;

    #endregion
#region ||~~~~~~~~|| private Fields ||~~~~~~~~||

    internal bool mouseUI;

    private byte number1, number2, number3;


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||




    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseUI = false;
    }








    public void ValuePlus(int index)
    {
        switch (index)
        {
            case 1:
                if (number1 >= 9) return;
                this.number1++;
                numberText1.text = this.number1.ToString();
                break;
            case 2:
                if (number2 >= 9) return;
                this.number2++;
                numberText2.text = this.number2.ToString();
                break;
            case 3:
                if (number3 >= 9) return;
                this.number3++;
                numberText3.text = this.number3.ToString();
                break;
        }
    }



    public void ValueMines(int index)
    {
        switch (index)
        {
            case 1:
                if (this.number1 <= 0) return;
                this.number1--;
                numberText1.text = this.number1.ToString();
                break;
            case 2:
                if (this.number2 <= 0) return;
                this.number2--;
                numberText2.text = this.number2.ToString();
                break;
            case 3:
                if (this.number3 <= 0) return;
                this.number3--;
                numberText3.text = this.number3.ToString();
                break;
        }
    }





    public void CorrectNumber()
    {
        if (this.number1 == 3 && this.number2 == 6 && this.number3 == 9)
        {
            this.gameManager._playerController.isMorse = true;
            Debug.Log("TRUE");
        }
        
    }
}