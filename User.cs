using System;
using System.Text;

namespace UserGenerator
{
    public class User : IComparable, IEquatable<User>
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

        public int CompareTo(object obj)
        {
            var other = obj as User;
            if(other == null)
            {
                throw new InvalidOperationException("obj must be of type User (or be castable to User)");
            }
            var result = this.FirstName.CompareTo(other.FirstName);
            if(result == 0)
            {
                result = this.LastName.CompareTo(other.LastName);
            }
            if(result ==0)
            {
                result = this.Domain.CompareTo(other.Domain);
            }
            return result;
        }

        public bool Equals(User other)
        {
            return this.CompareTo(other) == 0;
        }

        public override string ToString()
        {
            return $"{FullName} ({Email})";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            if (obj as User == null)
            {
                return false;
            }
            return this.Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Domain);
        }

        public static bool operator ==(User left, User right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(User left, User right)
        {
            return !(left == right);
        }

        public static bool operator <(User left, User right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(User left, User right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(User left, User right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(User left, User right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
    
}