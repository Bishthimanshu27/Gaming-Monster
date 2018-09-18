namespace OOP_RPG
{
    public class Potion : IItem
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Potion(string name,int Hp, int originalvalue, int resellvalue)
        {
            this.Name = name;
            this.HP = HP;
            this.OriginalValue = originalvalue;
            this.ResellValue = resellvalue;
        }
    }
}
