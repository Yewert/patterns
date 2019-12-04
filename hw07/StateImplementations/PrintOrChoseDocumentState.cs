using System;

namespace hw07.StateImplementations
{
    public class PrintOrChoseDocumentState : State
    {
        public override void InsertMoney(Context context, int count) => throw InvalidOperationForCurrentState;

        public override void ChooseSourceDevice(Context context, DeviceType device) => throw InvalidOperationForCurrentState;

        public override void ChooseDocument(Context context, string path)
        {
            context.State = new ChooseDocumentState();
            context.ChooseDocument(path);
        }

        public override void PrintDocument(Context context)
        {
            if (context.Document is null)
                throw InvalidOperationForCurrentState;
            
            var cost = GetCost(context.Document);
            if (context.Credit < cost)
                throw new InvalidOperationException("Not enough money");

            context.Credit -= cost;
            context.Printer.Print(context.Document.Path);
        }


        private int GetCost(Document document)
        {
            switch (document.Type)
            {
                case DocumentType.PDF:
                    return 10 * document.Pages;

                case DocumentType.JSON:
                    return 2 * document.Pages;

                default:
                    throw new ArgumentOutOfRangeException(nameof(document.Type), document.Type, null);
            }
        }
    }
}