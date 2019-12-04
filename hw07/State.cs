using System;
using hw07.StateImplementations;

namespace hw07
{
    public abstract class State
    {
        public abstract void InsertMoney(Context context, int count);
        public abstract void ChooseSourceDevice(Context context, DeviceType device);
        public abstract void ChooseDocument(Context context, string path);
        public abstract void PrintDocument(Context context);

        public int ReturnChange(Context context)
        {
            context.State = new InsertMoneyState();
            var change = context.Credit;
            context.Credit = 0;
            context.Device = DeviceType.None;
            return change;
        }

        protected readonly Exception InvalidOperationForCurrentState =
            new InvalidOperationException("This operation cannot be done from current state");
    }

    public enum DeviceType
    {
        None,
        UsbDrive,
    }

    public enum DocumentType
    {
        PDF,
        JSON
    }
    
    public class Document
    {
        public Document(DocumentType type, string path, int pages)
        {
            Type = type;
            Path = path;
            Pages = pages;
        }

        public DocumentType Type { get; }
        public string Path { get; }
        
        public int Pages { get; }
    }

    public class Context
    {
        public Document Document { get; set; }
        public DeviceType Device { get; set; }
        public int Credit { get; set; }
        public State State { get; set; }
        public IPrinter Printer { get; }
        public IDocumentInfoExtractor DocumentInfoExtractor { get; }

        public Context(IPrinter printer, IDocumentInfoExtractor documentInfoExtractor)
        {
            State = new InsertMoneyState();
            Printer = printer;
            DocumentInfoExtractor = documentInfoExtractor;
        }

        public void InsertMoney(int count)
        {
            State.InsertMoney(this, count);
        }

        public void ChooseDevice(DeviceType device)
        {
            State.ChooseSourceDevice(this, device);
        }

        public void ChooseDocument(string path)
        {
            State.ChooseDocument(this, path);
        }

        public void PrintDocument()
        {
            State.PrintDocument(this);
        }

        public int ReturnChange()
        {
            return State.ReturnChange(this);
        }
    }

    public interface IPrinter
    {
        void Print(string path);
    }

    public interface IDocumentInfoExtractor
    {
        Document Get(DeviceType device, string path);
    }
}