using System;

namespace FrameWork.Modles
{
    public class MirorrCard: Card
    {
        public override String Name {get; set;}= "Mirror";
        public override int Cost {get; set;} =1;
        public override String Rarity {get; set;}= "Epic";
        public override String Type {get; set;}= "Spell";
        public override String Arena {get; set;}= "Arena 12";
    }
}
