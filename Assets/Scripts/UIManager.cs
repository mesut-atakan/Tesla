using Inventory;
using Manager;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



internal class UIManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Public Fields
    
    public TextMeshProUGUI numberText1, numberText2, numberText3;

    public GameManager gameManager;


    public GameObject numberGameObject;



    public int[] neonNumbers = new int [9];





    [Header("NeonCembere")]

    public TextMeshPro[] neonTexts;



    internal GameObject _numberGameObject { get => this.numberGameObject; set => this.numberGameObject = value; }
    #endregion
#region ||~~~~~~~~|| private Fields ||~~~~~~~~||

    internal bool mouseUI;

    private byte number1, number2, number3;

    [HideInInspector]
    public int neonIndex = 0;




    public GameObject trPaper;
    public GameObject morsPaper;






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
            this.numberGameObject.SetActive(false);
            this.gameManager.uiManager.trPaper.SetActive(true);
            this.gameManager.uiManager.morsPaper.SetActive(false);
            
            Item searchItem = this.gameManager._inventoryManager.SearchItem("morsPaper");
            if (searchItem != null)
                this.gameManager._inventoryManager.InventoryRemoveItem(searchItem);
        }
        
    }







    public void ChangeNumber()
    {
        if (this.neonIndex >= 0 && neonIndex < 8)
        {
            neonIndex++;
        }
        else
        {
            this.neonIndex = 0;
        }

        Debug.Log(neonIndex);
        
    }

    public void IndexHesaplama()
    {
        if (this.neonNumbers[neonIndex] >= 9)
        {
            this.neonNumbers[neonIndex] = 0;
        }
        this.neonNumbers[this.neonIndex]++;
        this.neonTexts[neonIndex].text = this.neonNumbers[neonIndex].ToString();
    }



    public void NeonOnay()
    {
        if (this.neonNumbers[0] == 9 && this.neonNumbers[3] == 3 && this.neonNumbers[6] == 6)
        {
            Debug.Log("TRUE");
            this.gameManager.Key.SetActive(true);
        }
    }
}