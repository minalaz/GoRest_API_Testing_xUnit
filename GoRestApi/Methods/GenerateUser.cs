using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoRest.GoRestApi.Models;

namespace GoRest.GoRestApi.Methods
{
    public class GenerateUser
    {   
        public static User InstantiateUSer()
        {   RandomizingData randomizingData = new RandomizingData();
            User newUser = new User();
            newUser.name = randomizingData.GenerateRandomName();
            newUser.email = randomizingData.GenerateRandomEmail("example.com");
            newUser.gender = randomizingData.GenerateRandomGender();
            newUser.status = randomizingData.GenerateRandomStatus();

          return newUser;
        }
        public static User ParticularUser()
        {
            User newUser = new User();
            newUser.name = "Sanja Sanjic";
            newUser.email = "sanjica@gmail.com";
            newUser.gender = "female";
            newUser.status = "inactive";

            return newUser;
        }
        public static User InvalidUser()
        {
            User invalidUser = new User();
            invalidUser.name = null;
            invalidUser.email = "doradoric@gmail.com";
            invalidUser.gender = null;
            invalidUser.status = "inactive";
            return invalidUser;
        }
    }
}
