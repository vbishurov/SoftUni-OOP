namespace TheSlum.GameEngine
{
    using System;
    using Characters;
    using Items;
    using Items.Bonus;

    public class ImprovedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character newCharacter;
            switch (inputParams[1].ToLower())
            {
                case "warrior":
                    newCharacter = new Warrior(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), (Team)Enum.Parse(typeof(Team), inputParams[5], true));
                    this.characterList.Add(newCharacter);
                    break;
                case "mage":
                    newCharacter = new Mage(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), (Team)Enum.Parse(typeof(Team), inputParams[5], true));
                    this.characterList.Add(newCharacter);
                    break;
                case "healer":
                    newCharacter = new Healer(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), (Team)Enum.Parse(typeof(Team), inputParams[5], true));
                    this.characterList.Add(newCharacter);
                    break;
                default:
                    break;
            }
        }

        private new void AddItem(string[] inputParams)
        {
            Character designatedCharacter = GetCharacterById(inputParams[1]);
            Item itemToBeAdded;
            switch (inputParams[2].ToLower())
            {
                case "axe":
                    itemToBeAdded = new Axe(inputParams[3]);
                    designatedCharacter.AddToInventory(itemToBeAdded);
                    break;
                case "shield":
                    itemToBeAdded = new Shield(inputParams[3]);
                    designatedCharacter.AddToInventory(itemToBeAdded);
                    break;
                case "injection":
                    itemToBeAdded = new Injection(inputParams[3]);
                    designatedCharacter.AddToInventory(itemToBeAdded);
                    break;
                case "pill":
                    itemToBeAdded = new Pill(inputParams[3]);
                    designatedCharacter.AddToInventory(itemToBeAdded);
                    break;
                default:
                    break;
            }
        }
    }
}
