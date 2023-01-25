using Microsoft.Extensions.Configuration;
using Server.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace Server
{
    class Program
    {
        

        private const int portNum = 500;

    public static int Main(String[] args)
    {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("configmastercoin.json", optional: false);
            var config = builder.Build(); 
            


            bool done = false;

            string iplocal = config["ip"]; ; //ConfigurationManager.AppSettings["iplocal"];

        IPAddress ip = IPAddress.Parse(iplocal);

        var listener = new TcpListener(ip, portNum);

        listener.Start();

        while (!done)
        {
            //var xml1 = "<?xml version='1.0' encoding='UTF - 8'?><RemoteMessage operation='Device OK' DeviceID='MASTERCOIN' CustomerCode='' Date='2022-05-18' Time='13:54:18' NOP='3391'><content/><devStatus><dev name='BDM' machineId='1' mod='SDM 500C' err='OK' clean='0' door='0' devS='1' bag='0' cov='0' blk='00000000' ext='0'/></devStatus></RemoteMessage>";
            //var xml2 = "<?xml version='1.0' encoding='UTF-8'?><RemoteMessage operation='Deposit' DeviceID='MASTERCOIN' CustomerCode='' Date='2022-05-18' Time='11:40:48' NOP='3348'><TransactionID>3</TransactionID><User>100</User><UserName>Usu??rio</UserName><UserLevel>0</UserLevel><UserAlternateID/><accountingDate>2022-05-18</accountingDate><Details Currency='BRL'><total>5</total><countings valid='1'><counted denom='5' quantity='1' type='B'/></countings></Details><destDetails><count machineId='1' den='5' curr='BRL' qty='1' type='B' N='0' sType='B'/></destDetails><Conciliation/></RemoteMessage>";

            //var xml3 = "<?xml version='1.0' encoding='UTF-8'?><RemoteMessage operation='Deposit' DeviceID='WIN-9RL57SD6QN1' CustomerCode='' Date='2021-03-15' Time='17:12:55' NOP='136'><bagID machineId='2' N='0'>475869</bagID><bagID machineId='5' N='0'>2241536</bagID><TransactionID>10</TransactionID><User>002</User><UserName>Test admin</UserName><UserLevel>2</UserLevel><UserAlternateID>000022</UserAlternateID><UserOrganization>Cima</UserOrganization><UserInfo>user Informations</UserInfo><transactionRef>reference</transactionRef><TransactionInfo>Information</TransactionInfo><accountingDate>2021-03-15</accountingDate><Details Currency='EUR'><total>61.59</total><countings valid='6'><counted denom='0.02' quantity='2' type='C'/><counted denom='0.05' quantity='1' type='C'/><counted denom='0.5' quantity='1' type='C'/><counted denom='1' quantity='1' type='C'/><counted denom='10' quantity='1' type='B'/><counted denom='50' quantity='1' type='B'/></countings></Details><isKit>0</isKit><destDetails><count machineId='2' den='50' curr='EUR' qty='1' type='B' N='1' sType='R'/><count machineId='4' den='0.02' curr='EUR' qty='2' type='C' N='0' sType='B'/><count machineId='4' den='0.05' curr='EUR' qty='1' type='C' N='0' sType='B'/><count machineId='4' den='0.5' curr='EUR' qty='1' type='C' N='0' sType='B'/><count machineId='4' den='1' curr='EUR' qty='1' type='C' N='0' sType='B'/><count machineId='5' den='10' curr='EUR' qty='1' type='B' N='0' sType='B'/></destDetails><tickets><ticket type='Sodexo' barcode='0002826164239779600700452410160217' id='261642397796' curr='EUR' amount='7'/></tickets><cheques><cheque curr='EUR' codeline='+5279588#0065+ 1169# 0001080668- 4200>' amount='42'/></cheques><Conciliation/></RemoteMessage>";
            //var xml2 = "<?xml version='1.0' encoding='UTF-8'?><RemoteMessage operation='Device OK' DeviceID='MASTERCOIN' CustomerCode='' Date='2022-05-18' Time='11:40:52' NOP='3349'><content><count machineId='1' den='5' curr='BRL' qty='1' type='B' N='0' sType='B'/></content><devStatus><dev name='BDM' machineId='1' mod='SDM 500C' err='OK' clean='0' door='0' devS='1' bag='2' cov='0' blk='00000000' ext='0'/></devStatus></RemoteMessage>";
            //var xml2 = "<?xml version='1.0' encoding='UTF-8'?><RemoteMessage operation='Cash removal' DeviceID='MASTERCOIN' CustomerCode='' Date='2022-05-18' Time='11:41:09' NOP='3350'><TransactionID>4</TransactionID><User>300</User><UserName>Transportadora</UserName><UserLevel>1</UserLevel><UserAlternateID/><accountingDate>2022-05-18</accountingDate><Details Currency='BRL'><total>5</total><countings valid='1'><counted denom='5' quantity='1' type='B'/></countings></Details></RemoteMessage>";
            //var xml2 = "<?xml version='1.0' encoding='UTF-8'?><RemoteMessage operation='Cash bag removed' DeviceID='MASTERCOIN' CustomerCode='' Date='2022-05-18' Time='11:41:10' NOP='3351'><machineId>1</machineId></RemoteMessage>";




            Console.Write("Waiting for connection...");
            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("Connection accepted.");
            NetworkStream ns = client.GetStream();

            byte[] bytes = new byte[1024];
            int bytesRead = ns.Read(bytes, 0, bytes.Length);



            var xml = Encoding.ASCII.GetString(bytes, 0, bytesRead);

            XmlModel logxml = new XmlModel();

            logxml.Conteudo = xml;
            logxml.DataRecebimento = DateTime.Now;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RemoteMessage));
                using (StringReader reader = new StringReader(xml))
                {
                    var message = (RemoteMessage)serializer.Deserialize(reader);
                    using (var context = new MasterContext())
                    {
                        context.RemoteMessages.Add(message);

                        if (message.Operation == "Deposit" || message.Operation == "Manual Deposit")
                        {
                            var equipamento = context.Equipamentos.Where(e => e.Descricao == message.DeviceID).First();
                            equipamento.AdicionarSaldo(message.Details.Total);
                        }

                        if (message.Operation == "Cash removal" || message.Operation == "Withdrawal")
                        {
                            var equipamento = context.Equipamentos.Where(e => e.Descricao == message.DeviceID).First();
                            equipamento.RetirarSaldo(message.Details.Total);
                        }

                        logxml.Status = 1;
                        context.Log.Add(logxml);
                        context.SaveChanges();
                    }
                }

            }
            catch
            {
                using (var context = new MasterContext())
                {
                    logxml.Status = 0;
                    context.Log.Add(logxml);
                    context.SaveChanges();
                }
            }




            Console.WriteLine(xml);





        }

        //listener.Stop();

        return 0;
    }
}
}
