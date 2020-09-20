using System;

namespace FrameWork.Modles
{
    public class IceSpiritCard: Card
    {
        public override String Name {get; set;}= "Ice Spirit";
        public override int Cost {get; set;} =1;
        public override String Rarity {get; set;}= "Common";
        public override String Type {get; set;}= "Troop";
        public override String Arena {get; set;}= "Arena 8";
    }
}
