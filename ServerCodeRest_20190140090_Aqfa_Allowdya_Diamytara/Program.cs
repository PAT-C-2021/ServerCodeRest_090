using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using ServiceRest_090_Aqfa_Allowdya_Diamytara;

namespace ServerCodeRest_20190140090_Aqfa_Allowdya_Diamytara
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:1907/Mahasiswa");
            WebHttpBinding binding = new WebHttpBinding();
            try
            {
                hostObj = new ServiceHost(typeof(TI_UMY), address);
                hostObj.AddServiceEndpoint(typeof(ITI_UMY), binding, "");
               
                
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); 
                smb.HttpGetEnabled = true;
                hostObj.Description.Behaviors.Add(smb);
                Binding mexbind = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexbind, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObj.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
