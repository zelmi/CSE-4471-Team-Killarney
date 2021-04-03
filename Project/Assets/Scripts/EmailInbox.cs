using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets.Scripts
{
    //Class for representing an email inbox tab, serializable to persist across email sessions
    public class EmailInbox
    {
        //Message class for each individual message
        public class Message
        {
            [XmlAttribute]
            public string senderOrRecipient;
            [XmlAttribute]
            public string subject;
            [XmlAttribute]
            public string time;
            [XmlAttribute]
            public string text;

            //No argument constructor necessary for serialization
            public Message()
            {
                senderOrRecipient = "Sender";
                subject = "Subject";
                time = "Time";
                text = "Text";

            }

            public Message(string senderOrRecipient, string subject, string time, string text)
            {
                this.senderOrRecipient = senderOrRecipient;
                this.subject = subject;
                this.time = time;
                this.text = text;
            }
        }

        //Tracks the type of the email inbox
        [XmlAttribute]
        public string type;

        //List of messages
        public List<Message> messageList;

        //Constructor
        public EmailInbox()
        {
            messageList = new List<Message>();
        }
    }
}
