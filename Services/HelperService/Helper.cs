using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.HelperService
{
    public class Helper
    {
        public static async Task<dynamic> ErrorLog(string errMsg)
        {
            try
            {
                string path = string.Empty;
                string folder = string.Empty;
                folder = DateTime.UtcNow.ToString("yyyMMdd");
                path = Directory.GetCurrentDirectory() + @"/../Error/" + folder + "/";
                _ = Directory.CreateDirectory(path);
                await File.WriteAllTextAsync(path + DateTime.UtcNow.ToString("yyyyMMddHHmmssFFF") + "_error.txt", errMsg.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return 0;
        }
    }
}
