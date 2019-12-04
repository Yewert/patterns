namespace hw07.StateImplementations
{
    public class InsertMoneyState : State
    {
        public override void InsertMoney(Context context, int count)
        {
            context.Credit = count;
            context.State = new ChooseSourceDeviceState();
        }

        public override void ChooseSourceDevice(Context context, DeviceType device) => throw InvalidOperationForCurrentState;

        public override void ChooseDocument(Context context, string path) => throw InvalidOperationForCurrentState;

        public override void PrintDocument(Context context) => throw InvalidOperationForCurrentState;
    }
}