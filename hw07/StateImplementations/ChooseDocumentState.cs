using System;

namespace hw07.StateImplementations
{
    public class ChooseDocumentState : State
    {
        public override void ChooseDocument(Context context, string path)
        {
            if (context.Device == DeviceType.None)
            {
                throw new InvalidOperationException();
            }
            context.Document = context.DocumentInfoExtractor.Get(context.Device, path);
            context.State = new PrintOrChoseDocumentState();
        }

        public override void InsertMoney(Context context, int count) => throw InvalidOperationForCurrentState;
        public override void ChooseSourceDevice(Context context, DeviceType device) => throw InvalidOperationForCurrentState;
        public override void PrintDocument(Context context) => throw InvalidOperationForCurrentState;
    }
}