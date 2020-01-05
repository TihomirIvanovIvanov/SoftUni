namespace IRunes.App.ViewModels.Tracks
{
    public class TrackCreateInputModel
    {
        private const string NameErroMessage = "Track name must be between 3 and 20 symbols!";

        private const string LinkErroMessage = "Link name must be longer than 3 symbols!";

        private const string PriceErroMessage = "Invalid price!";

        [RequiredSis]
        public string AlbumId { get; set; }

        [RequiredSis]
        [StringLengthSis(3, 20, NameErroMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [StringLengthSis(4, int.MaxValue, LinkErroMessage)]
        public string Link { get; set; }

        [RangeSis(typeof(decimal), "0.00", "79228162514264337593543950335", PriceErroMessage)]
        public decimal Price { get; set; }
    }
}
