namespace MusicShopManager.Models.Articles.MusicalInstruments.Guitars
{
    using System.Text;
    using Interfaces;

    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private const bool IsElectronicInstrument = false;
        private const int AcousticGuitarNumberOfStrings = 6;

        public AcousticGuitar(
            string make,
            string model,
            decimal price,
            string color,
            string bodyWood,
            string fingerboardWood,
            bool caseIncluded,
            StringMaterial stringMaterial)
            : base(
            make,
            model,
            price,
            color,
            AcousticGuitar.IsElectronicInstrument,
            bodyWood, fingerboardWood,
            AcousticGuitar.AcousticGuitarNumberOfStrings)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; private set; }

        public StringMaterial StringMaterial { get; private set; }

        public override string ToString()
        {
            StringBuilder acousticGuitar = new StringBuilder();
            acousticGuitar.Append(base.ToString());
            acousticGuitar.AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no").AppendLine();
            acousticGuitar.AppendFormat("String material: {0}", this.StringMaterial).AppendLine();

            return acousticGuitar.ToString();
        }
    }
}
