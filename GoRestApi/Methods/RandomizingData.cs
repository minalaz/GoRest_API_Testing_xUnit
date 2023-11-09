using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace GoRest.GoRestApi.Methods
{
    public class RandomizingData
    {
        private static Random random = new Random();

        public string GenerateRandomName()
        {
            //letters or numbers to make a name
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            //it picks random number between these two to make a name of certain length
            int length = random.Next(2, 10);
            //future nameHolder
            StringBuilder name = new StringBuilder();
            //repeating steps as many times as the length is
            for (int i = 0; i < length; i++)
            {
                //picks a random letter or number from the characters and adds it to the end of the name.
                name.Append(characters[random.Next(characters.Length)]);
            }


            //returning name as a string
            return name.ToString();
        }
        public string GenerateRandomEmail(string domain)
        {
           
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int length = random.Next(5, 15);

            StringBuilder email = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                //adds characters for first part of the name
                email.Append(characters[random.Next(characters.Length)]);
            }
            //it adds @ to the first part of the name
            email.Append("@");
            //it adds domain 
            email.Append(domain);

            return email.ToString();
        }

        public string GenerateRandomGender()
        {   
            
            int randomNumber = random.Next(3); // Generates a random number between 0 and 2

            switch (randomNumber)
            {
                case 0:
                    return "male";
                case 1:
                    return "female";
                default:
                    return "other";
            }
        }
        public string GenerateRandomStatus() {
            
            int randomNumber = random.Next(2);
            switch (randomNumber)
            {
                case 0:
                    return "inactive";
                    default:
                    return "active";


            }
        } } }
