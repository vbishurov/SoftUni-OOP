namespace Infestation.Logic
{
    using System;
    using Models.Supplements;
    using Models.Supplements.Catalists;
    using Models.Units.Biological;
    using Models.Units.Mechanical;
    using Models.Units.Psionic;

    class ImprovedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var unit = this.GetUnit(commandWords[2]);

            switch (commandWords[1])
            {
                case "Weapon":
                    var weapon = new Weapon();
                    unit.AddSupplement(weapon);
                    break;
                case "AggressionCatalyst":
                    var aggressionCatalyst = new AggressionCatalyst();
                    unit.AddSupplement(aggressionCatalyst);
                    break;
                case "HealthCatalyst":
                    var healthCatalyst = new HealthCatalyst();
                    unit.AddSupplement(healthCatalyst);
                    break;
                case "PowerCatalyst":
                    var powerCatalyst = new PowerCatalyst();
                    unit.AddSupplement(powerCatalyst);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
