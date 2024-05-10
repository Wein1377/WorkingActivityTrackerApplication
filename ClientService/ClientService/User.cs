using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int profileId { get; set; }

        public User(int Id, string FirstName, string LastName, int ProfileId)
        {
            this.id = Id;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.profileId = ProfileId;
        }
    }
}
