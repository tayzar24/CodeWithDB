using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Common
{
    public class CreateMessage
    {
        public static string CreateResultMessage(Exception ex)
        {
            string errorMessage = string.Empty;

            if (ex.Message.Contains("The server was not found or was not accessible."))
            {
                errorMessage = "Database Connection is faliure!.";
            }
            else
            {
                errorMessage = ex.Message.ToString();
            }

            return errorMessage;
        }
    }
}
