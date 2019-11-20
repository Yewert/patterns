using System.Collections.Generic;
using System.Linq;

namespace DecoratorsHomework
{
    static class DecoratedClientFactory
    {
        public static IChatClient Decorate(IChatClient chatClient)
        {
            return new MessageEncryptingDecorator(new NameHidingDecorator(chatClient));
        }
    }
    
    class Message
    {
        public Message(string @from, string to, string text)
        {
            From = @from;
            To = to;
            Text = text;
        }

        public string From { get; }
        public string To { get; }
        public string Text { get; }
    }

    interface IChatClient
    {
        void Send(Message message);
        List<Message> GetAll();
    }

    abstract class ChatClientDecoratorBase : IChatClient
    {
        private readonly IChatClient client;

        protected ChatClientDecoratorBase(IChatClient client)
        {
            this.client = client;
        }

        protected abstract Message Transform(Message original);

        public virtual void Send(Message message)
        {
            client.Send(Transform(message));
        }

        public List<Message> GetAll()
        {
            return client.GetAll()
                .Select(Transform)
                .ToList();
        }
    }

    class NameHidingDecorator : ChatClientDecoratorBase
    {
        public NameHidingDecorator(IChatClient client) : base(client)
        {
            
            }

        private string Hide(string str)
        {
            return string.Join("", Enumerable.Repeat("#", str.Length));
        }

        protected override Message Transform(Message original)
        {
            return new Message(Hide(original.From), Hide(original.To), original.Text);
        }
    }
    
    class MessageEncryptingDecorator : ChatClientDecoratorBase
    {
        public MessageEncryptingDecorator(IChatClient client) : base(client)
        {
            
        }

        private string Encrypt(string str)
        {
            return $"<encrypted>{str}</encrypted>";
        }

        protected override Message Transform(Message original)
        {
            return new Message(original.From, original.To, Encrypt(original.Text));
        }
    }
}