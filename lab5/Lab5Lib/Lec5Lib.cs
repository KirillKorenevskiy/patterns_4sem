using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Lib
{
    public interface IWriter
    {
        string? Save(string? message);
    }

    public static class Constant
    {
        public const char Delimiter = '\uffff';
        public const string FileName = "DP.txt";
    }


    public class FileWriter : IWriter
    {
        string filename = Constant.FileName;
        public string FileName { get { return this.filename; } }
        public FileWriter(string? filename = null)
        {
            this.filename = filename ?? Constant.FileName;
        }
        public string? Save(string? text)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filename);
                writer.WriteLine(text);
            }
            catch (Exception)
            {
                return null;
            }

            return this.filename;
        }
    }


    public class StrWriter : IWriter
    {
        public string? Save(string? message)
        {
            return message;
        }
    }


    public abstract class Decorator : IWriter //базовый
    {
        protected IWriter? writer;
        public Decorator(IWriter? writer)
        {
            this.writer = writer;
        }
        public virtual string? Save(string? message)
        {
            return writer.Save(message);
        }
    }


    public class DecSHA512 : Decorator
    {
        public DecSHA512(IWriter writer) : base(writer) { }
        public override string? Save(string? message) 
        {
            if (message != null)
            {
                byte[] hash = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(message));
                string hashedMessage = message + Constant.Delimiter + Convert.ToBase64String(hash);
                return writer?.Save(hashedMessage);
            }
            return null;
        }
    }


    public class DecMD5 : Decorator
    {
        public DecMD5(IWriter writer) : base(writer) { }
        public override string? Save(string? message)
        {
            if (message != null)
            {
                byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(message));
                string hashedMessage = message + Constant.Delimiter + Convert.ToBase64String(hash);
                return writer?.Save(hashedMessage);
            }

            return null;
        }
    }


    public class DecRSA : Decorator
    {
        public DecRSA(IWriter writer) : base(writer) { }

        public override string? Save(string message)
        {
            string publicKeyXml;
            byte[] encyptedData;

            message = message ?? string.Empty;

            int k1 = message.IndexOf(Constant.Delimiter);

            if (k1 == -1)
            { 
                throw new Exception("разделитель не найден"); 
            }

            string xs = message.Substring(0, k1);
            string xsbhcs = message.Substring(k1 + 1);
            byte[] xsbhc = Convert.FromBase64String(xsbhcs);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                publicKeyXml = rsa.ToXmlString(true);
                rsa.ImportParameters(rsa.ExportParameters(false));
                encyptedData = rsa.Encrypt(xsbhc, false);
            }

            string result = $"{xs}{Constant.Delimiter}{Convert.ToBase64String(encyptedData)}{Constant.Delimiter}{publicKeyXml}";
            return writer.Save(result);
        }

    }
}
