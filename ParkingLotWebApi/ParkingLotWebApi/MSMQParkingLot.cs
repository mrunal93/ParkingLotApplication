using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLotWebApi
{
    public class MSMQParkingLot
    {
        readonly MessageQueue messageQueue = new MessageQueue();
        public MSMQParkingLot()
        {
            this.messageQueue.Path = @".\private$\ParkingLot";
            if (!MessageQueue.Exists(this.messageQueue.Path))
            {
                this.messageQueue = MessageQueue.Create(this.messageQueue.Path);
            }
            
        }

        public void Sender(string message)
        {
            try
            {
                this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                this.messageQueue.ReceiveCompleted += this.ReceiverQueue;

                this.messageQueue.Send(message);

                this.messageQueue.BeginReceive();

                this.messageQueue.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void ReceiverQueue(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = this.messageQueue.EndReceive(e.AsyncResult);
            string data = msg.Body.ToString();
            using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + @"\MsmqMessageForParking.txt", true))
            {
                file.WriteLine(data);
            }
            this.messageQueue.BeginReceive();
        }
    }
}
