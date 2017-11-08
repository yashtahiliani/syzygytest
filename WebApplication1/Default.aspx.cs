using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        protected void sub_Click(object sender, EventArgs e)
        {
            // We have to iterate through the csv file and store the values in a collection

            string csvpath = Server.MapPath(upfile.PostedFile.FileName);

            upfile.SaveAs(csvpath);

            string csvData = File.ReadAllText(csvpath);

            csvData = csvData.Replace("\r\n", "");

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (string row in csvData.Split(','))
            {
                if (!string.IsNullOrWhiteSpace(row))
                {

                    string r = String.Concat(row.OrderBy(c => c)).Replace(" ", "");

                    if (!dic.ContainsKey(r))
                        dic.Add(r, 1);
                    else
                    {
                        int num = dic[r];
                        dic[r] = num + 1;
                    }
                }
            }

            // Once we have this collection, we need to group them by number of letters

            Dictionary<string, int> odic = new Dictionary<string, int>();

            foreach(KeyValuePair<string, int> d in dic)
            {
                if (d.Value > 1)
                {
                    // Now that we have an instance of similar words, we need to group them by number of letters

                    string c = d.Key.Length.ToString();

                    if (odic.ContainsKey(c))
                    {
                        odic[c] += d.Value;
                    }
                    else
                        odic.Add(c.ToString(), d.Value);
                }
            }

            // Now that we have a collection of grouped words, we need to output this to a text file.

            string saveurl = Server.MapPath("~");

            using (StreamWriter file = new StreamWriter(saveurl + "results.txt"))
            {
                foreach (var entry in odic)
                {
                    file.WriteLine("Number of letters: {0} | Words: {1}", entry.Key, entry.Value);
                }
            }

        }
    }
}