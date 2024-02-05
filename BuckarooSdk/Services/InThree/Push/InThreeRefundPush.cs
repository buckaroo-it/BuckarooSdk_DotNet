namespace BuckarooSdk.Services.InThree.Push
{
    public class InThreeRefundPush : ActionPush
    {
        public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.In3;

        internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
        {
            base.FillFromPush(serviceResponse);
        }
    }
}
