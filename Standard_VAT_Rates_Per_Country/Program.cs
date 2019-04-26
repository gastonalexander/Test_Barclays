using System;
using System.Windows.Forms;

namespace Standard_VAT_Rates_Per_Country
{
    static class Program
    {
        [STAThread]
        static void Main()
        {          
            ReadJsonData readJsonData = new ReadJsonData();
            readJsonData.ReadJson();
            Application.Run();
        }
    }
}
