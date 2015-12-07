using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace b64encode
{
  class Program
  {
    static void Main(string[] args)
    {
      StreamReader sr = new StreamReader(Console.OpenStandardInput());
      StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
      
      if(Environment.CommandLine.ToLower().Contains("decode")) {
        sw.Write(B64Decode(sr.ReadToEnd()));
      } else {
        sw.Write(B64Encode(sr.ReadToEnd()));
      }
      sr.Close();
      sw.Close();   
    }

    public static string B64Encode(string str)
    {
      string result = "";
      try
      {
        byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(encbuff);
      }
      catch
      {
        result = "";
      }
      return result;
    }

    public static string B64Decode(string str)
    {
      string result = "";
      try
      {
        byte[] decbuff = Convert.FromBase64String(str);
        result = System.Text.Encoding.UTF8.GetString(decbuff);
      }
      catch
      {
        result = "";
      }
      return result;
    }

  }
}
