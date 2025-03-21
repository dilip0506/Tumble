using System;
using System.Collections.Generic;
using System.Text;

namespace Tumble.DataAccess.Account
{
    public static class UsersQueries
    {
        #region Registration
        public static string InsertUser = @"INSERT INTO tumbleuser (firstname,lastname,passwordhash,passwordsalt,phone,email,addressid)
                                          VALUES (@FirstName,@LastName,@PasswordHash,@PasswordSalt,@Phone,@Email,@AddressId) RETURNING userid;";
        
        public static string InsertAddress = @"INSERT INTO address (street,streetoptional,city,state,zipcode)
                                          VALUES (@Street,@StreetOptional,@City,@State,@ZipCode) RETURNING addressid;";

        public static string InsertRegistrationVerificationDetails = @"INSERT INTO userregistrationverification (UserId,VerficationCode,StatusCode)
                                          VALUES (@UserId,@VerficationCode,@StatusCode);";
        #endregion

        #region User
        public static string SelectUser = @"SELECT * FROM tumbleuser WHERE email = @Email;";
        #endregion
    }
}
