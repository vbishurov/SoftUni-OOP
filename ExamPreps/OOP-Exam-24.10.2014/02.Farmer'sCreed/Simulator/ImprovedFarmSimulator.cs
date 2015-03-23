namespace FarmersCreed.Simulator
{
    using Interfaces;
    using Units.Animals;
    using Units.Plants;

    class ImprovedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "exploit":
                    {
                        this.ExploitUnit(inputCommands[1], inputCommands[2]);
                        break;
                    }
                case "feed":
                    {
                        this.FeedAnimal(inputCommands[1], inputCommands[2], inputCommands[3]);
                        break;
                    }
                case "water":
                    {
                        this.WaterPlant(inputCommands[1]);
                        break;
                    }
                default:
                    base.ProcessInput(input);
                    break;
            }
        }

        private void WaterPlant(string id)
        {
            this.GetPlantById(id).Water();
        }

        private void FeedAnimal(string id, string product, string amount)
        {
            this.GetAnimalById(id).Eat(this.GetProductById(product) as IEdible, int.Parse(amount));
        }

        private void ExploitUnit(string type, string id)
        {
            switch (type)
            {
                case "animal":
                    {
                        var animalProduct = this.GetAnimalById(id).GetProduct();
                        this.farm.AddProduct(animalProduct);
                        break;
                    }
                case "plant":
                    {
                        var plantProduct = this.GetPlantById(id).GetProduct();
                        this.farm.AddProduct(plantProduct);
                        break;
                    }
            }
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    {
                        var cherryTree = new CherryTree(id);
                        this.farm.Plants.Add(cherryTree);
                        break;
                    }
                case "Cow":
                    {
                        var cow = new Cow(id);
                        this.farm.Animals.Add(cow);
                        break;
                    }
                case "Swine":
                    {
                        var swine = new Swine(id);
                        this.farm.Animals.Add(swine);
                        break;
                    }
                case "TobaccoPlant":
                    {
                        var tobacco = new TobaccoPlant(id);
                        this.farm.Plants.Add(tobacco);
                        break;
                    }
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }
    }
}
