﻿namespace MyTunesShop.Models.Performers
{
    using System.Collections.Generic;

    class Band : Performer, IBand
    {
        public Band(string name)
            : base(name)
        {
            this.Members = new List<string>();
        }

        public override PerformerType Type
        {
            get
            {
                return PerformerType.Band;
            }
        }

        public IList<string> Members { get; private set; }

        public void AddMember(string memberName)
        {
            this.Members.Add(memberName);
        }
    }
}
