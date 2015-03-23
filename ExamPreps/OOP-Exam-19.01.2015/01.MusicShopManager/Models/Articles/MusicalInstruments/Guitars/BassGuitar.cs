namespace MusicShopManager.Models.Articles.MusicalInstruments.Guitars
{
    using Interfaces;

    public class BassGuitar : Guitar, IBassGuitar
    {
        private const bool IsElectronicInstrument = true;
        private const int BassGuitarNumberOfStrings = 4;

        public BassGuitar(
            string make,
            string model,
            decimal price,
            string color,
            string bodyWood,
            string fingerboardWood)
            : base(
            make, 
            model, 
            price,
            color, 
            BassGuitar.IsElectronicInstrument, 
            bodyWood, fingerboardWood,
            BassGuitar.BassGuitarNumberOfStrings)
        {
        }
    }
}
