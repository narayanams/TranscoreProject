namespace CallSPFromAzureFunction
{
    using System;
    using System.Threading;
    using RabbitMQ.Client;
    using System.Text;


    public class RabbitProducer
    {
        private IConnection connection;
        private IModel channel;

        public void Connect()
        {
            
                ConnectionFactory factory = new ConnectionFactory
                {
                    HostName = ConnectionConstants.HostName,                 
                    UserName = ConnectionConstants.UserName,
                    Password = ConnectionConstants.Password,
                    Port = ConnectionConstants.Port,
                    VirtualHost =  ConnectionConstants.VirtualHost
                };

               

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(ConnectionConstants.QueueName, false, false, false, null);            
        }

        public void Disconnect()
        {
            channel = null;

            if (connection.IsOpen)
            {
                connection.Close();
            }

            connection.Dispose();
            connection = null;
        }

        private const int MessageCount = 10;
     
        public string SendSimpleMessage(string MessageBody, int Index)
        {
            SimpleMessage message = new SimpleMessage
            {
                Id = Index,
                Text = MessageBody
            };
            return  SendMessage(MessageBody);            
        }
             
        private string SendMessage(string Message)
        {

            try
            {

                var properties = channel.CreateBasicProperties();
                properties.Persistent = false;
                byte[] messagebuffer = Encoding.Default.GetBytes(Message);

                channel.BasicPublish(ConnectionConstants.Exchange, ConnectionConstants.QueueName, properties, messagebuffer);

                return "";
            }
            catch(Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }
    }
}
