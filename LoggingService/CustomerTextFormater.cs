﻿using Serilog.Events;
using Serilog.Formatting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggingService
{
    public class CustomerTextFormater : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            //// Credit to format from : https://dev.azure.com/Techhowdy/_git/CMS_CORE_NG?path=%2FLoggingService%2FCustomTextFormatter.cs
            if (logEvent.Level.ToString() != "Information")
            {
                output.WriteLine("----------------------------------------------------------------------");
                output.WriteLine($"Timestamp - {logEvent.Timestamp} | Level - {logEvent.Level} |");
                output.WriteLine("----------------------------------------------------------------------");
                foreach (var item in logEvent.Properties)
                {
                    output.WriteLine(item.Key + " : " + item.Value);
                }
                if (logEvent.Exception != null)
                {
                    output.WriteLine("----------------------EXCEPTION DETAILS-------------------------------");
                    output.Write("Exception - {0}", logEvent.Exception);
                    output.Write("StackTrace - {0}", logEvent.Exception.StackTrace);
                    output.Write("Message - {0}", logEvent.Exception.Message);
                    output.Write("Source - {0}", logEvent.Exception.Source);
                    output.Write("InnerException - {0}", logEvent.Exception.InnerException);
                }
                output.WriteLine("---------------------------------------------------------------------------");
            }
        }
    }
}
