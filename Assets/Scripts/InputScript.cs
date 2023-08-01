using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;

public class InputScript : MonoBehaviour
{
    public Text text;
    public string rownanie;
    [SerializeField]private TMP_InputField inputField;
    // Start is called before the first frame update
    public void SetText()
    {
        rownanie = inputField.text.ToString();
        string result = CalculateEquation(rownanie);
        text.text = result.ToString();
    }
    private string CalculateEquation(string equation)
    {
        try
        {
            string f = equation;
            if (f.Contains("^")) { return equation; }
            f = f.Replace("X", "x"); // zmiana duzych X na male x
            f = f.Replace("E", "e");
            f = f.Replace("e", "2.718281");
            double tmp2 = 1;

            string tmp = f;
            string tmp3 = tmp2.ToString();
            tmp = tmp.Replace("x", tmp3);

            var parsedExpression = new Expression(tmp);
            var result = parsedExpression.Evaluate(null);
            return result.ToString();
        }
        catch
        {
            return equation;
        }
    }

}
