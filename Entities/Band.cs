using System;

namespace bands_repository_csharp.Entities
{
    public class Band : Base
    {
        public Band(int Id, string name, int formedYear, int numberAlbums, bool deleted)
        {
            this.Id = Id;
            this.Name = name;
            this.FormedYear = formedYear;
            this.NumberAlbums = numberAlbums;
            this.Deleted = false;
        }

        private string Name { get; set; }
        private int FormedYear { get; set; }
        private int NumberAlbums { get; set; }
        private bool Deleted { get; set; }

        public int getId()
        {
            return this.Id;
        }

        public string getName()
        {
            return this.Name;
        }

        public bool getDeleted()
        {
            return this.Deleted;
        }
        public void delete()
        {
            this.Deleted = true;
        }

        public override string ToString()
        {
            string returnBand = "";
            returnBand += "Name" + this.Name + Environment.NewLine;
            returnBand += "Formed Year" + this.FormedYear + Environment.NewLine;
            returnBand += "Number of Albums" + this.NumberAlbums + Environment.NewLine;
            returnBand += "Is Deleted" + this.Deleted;
            return returnBand;
        }
    }
}