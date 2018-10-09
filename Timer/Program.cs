using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGA.Tools.Timer
{
    class Program
    {
        const string DEFAULT_FORMAT_STRING = "{0:dd\\.hh\\:mm\\:ss\\.fff}";
        static void Main(string[] args)
        {
            DateTime current = DateTime.Now;
            long now = current.ToBinary();
            if (!args.Any())
            {
                Console.WriteLine(now);
            }
            else
            {
                try
                {

                    long oldStamp, newStamp;
                    DateTime oldTime;
                    DateTime newTime;
                    if (long.TryParse(args[0], out oldStamp))
                    {
                        oldTime = DateTime.FromBinary(oldStamp);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid timestamp provided!");
                    }
                    if (args.Length > 1)
                    {
                        if (long.TryParse(args[1], out newStamp))
                        {
                            newTime = DateTime.FromBinary(newStamp);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid timestamp provided!");
                        }
                    }
                    else
                    {
                        newTime = current;
                    }
                    TimeSpan span = newTime - oldTime;
                    string formatString = DEFAULT_FORMAT_STRING;
                    string outputString;
                    if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("outputFormat"))
                    {
                        formatString = System.Configuration.ConfigurationManager.AppSettings["outputFormat"];
                       try
                       {
                            outputString = string.Format(formatString, span);
                        }
                       catch (System.Exception ex)
                       {
                            outputString = string.Format(DEFAULT_FORMAT_STRING, span);
                       }
                    }
                    else
                    {
                        outputString = string.Format(DEFAULT_FORMAT_STRING, span);
                    }
                    Console.WriteLine(outputString);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
        }
    }
}
