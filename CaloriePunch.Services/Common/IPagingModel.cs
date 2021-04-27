namespace CaloriePunch.Services.Common
{
    public interface IPagingModel
    {
        int Index { get; set; }
        int Skip { get; set; }
        int Take { get; set; }
    }
}