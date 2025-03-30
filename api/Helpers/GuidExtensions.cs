namespace api.Helpers
{
    public static class GuidExtensions
    {
        public static Guid GenerateId()
        {
            return Guid.NewGuid();
        }

    }
}
