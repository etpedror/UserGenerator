using System.Text;

namespace UserGenerator
{
    public class User
    {
        /// <summary>
        /// The user's first name
        /// </summary>
        public string FirstName {get;set;}

        /// <summary>
        /// The user's last name
        /// </summary>
        public string LastName {get;set;}

        /// <summary>
        /// The user's domain
        /// </summary>
        public string Domain {get;set;}

        /// <summary>
        /// The user's password
        /// </summary>
        public string Password {get;set;}

        /// <summary>
        /// The full name of the user
        /// </summary>
        public string FullName {get => $"{FirstName} {LastName}"; }
        
        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get => FullName.Replace(" ", "").ToLowerInvariant(); }

        /// <summary>
        /// The email address of the user
        /// </summary>
        public string Email {get => $"{Username}@{Domain}";}

        /// <summary>
        /// The phonetic representation of the password
        /// </summary>
        public string PhoneticPassword { 
            get
            {
                var result = new StringBuilder();
                foreach (var character in Password)
                {
                    result.Append(Phonetic.Table["" + character] + " ");
                }
                return result.ToString().Trim();
            }
        }
    }
    
}