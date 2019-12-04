namespace hw07.StateImplementations
{
    public class ChooseSourceDeviceState : State
    {
        public override void InsertMoney(Context context, int count) => throw InvalidOperationForCurrentState;

        public override void ChooseSourceDevice(Context context, DeviceType device)
        {
            context.Device = device;
            context.State = new ChooseDocumentState();
        }

        public override void ChooseDocument(Context context, string path)=> throw InvalidOperationForCurrentState;

        public override void PrintDocument(Context context) => throw InvalidOperationForCurrentState;
    }
}