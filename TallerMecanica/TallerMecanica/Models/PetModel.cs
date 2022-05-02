namespace TallerMecanica.Models
{
    public class PetModel
    {
        //Fields
        private int id;
        private string name;
        private string type;
        private string colour;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
    }
}
