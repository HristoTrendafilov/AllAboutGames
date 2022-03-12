namespace AllAboutGames.Data.ViewModels
{
    public class DeveloperViewModel
    {
        public int DeveloperID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
