# Useful links
* [Start here for Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.1&tabs=visual-studio)
* [Scaffold Identity into a new Project](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-2.1&tabs=visual-studio)
* [Configure Identity Password and Cookies](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-2.1)
* [ALL of Identity Class Documentation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore?view=aspnetcore-1.1)


# Add Identity to a Project
## Packages Required for Identity
`Microsoft.AspNetCore.Identity.EntityFrameworkCore`
`Microsoft.AspNetCore.Identity`

You will need both these packages installed to use Identity
BUT
if you have the `Microsoft.AspNetCore.App` installed you already have all
packages for Identity

## Extend IdentityDBContext
Your DBContext needs to extend IdentityDBContext
add this using statements to the file to get access to IdentityDBContext
`using Microsoft.AspNetCore.Identity.EntityFrameworkCore;`


Once extended when you run your next migrations it will created several tables that
Identity uses, these tables are:
* **AspNetUser**
* **AspNetRoles**
* **AspNetUserRoles**
* AspNetUserClaims
* AspNetUserLogins
* AspNetUserTokens
* AspNetRoleClaims

The ones in bold are the only ones I've ever had to deal with.

# The Tables

## AspNetUser

The User tables comes with a bunch of stuff right out the gate.

Like:
* UserName
* Email
* PhoneNumber
* PasswordHash
* ID

Check your created AspNetUser table to see everything or look online.

### I want to add my own user properties

If you want that then you need to extend the AspNetUser class and add your custom
properties to that. Look within the models folder of this repo for a example.

## AspNetRoles

The roles table are all the roles within this system. You can create roles then give
user that role to only allow them access to certain content within the system.

Roles only has a **Name** and a **ID**

## AspNetUserRoles

This table is the M to M mapping between user and roles. This allows a
user to have many roles within the system and roles can have many users.

The only two fields are **roleId** and **userId**

That should be all you need to get started. For more info on the other tables. google.

## I hate the name of these Tables

You can give them a new name if you want. You have to use Fluent API in order to do this.
Take a look at the 'ApplicationDbContext onModelBuilder' method for an example.

# Gotchas

## Seeding users
  If you are manually creating users then their are fields that the UserManager would
  usually fill for you but you have to fill if your are adding to the DB yourself.

  These fields are:
  * NormalizeUserName
  * NormalizeEmail
  * PasswordHash
  * SecurityStamp

  Normalize just means in all captial letters
  The security stamp you can generate with `Guid.NewGuid().ToString()`
  for password hash you can create your own passwordhasher and hash a password.


# The Managers

The managers are basically repository patterns to save you from writing your own
sql lookups to get information from Identity.

## UserManager

Handles everything about a User. You can get a User from their ID from here,
create a user, and more.

Look at the UserManager docs here => https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.usermanager-1?view=aspnetcore-2.1

## SignInManager

Handles signin a user for you. Also does sign out. You don't need to give them the cookie,
it does it for you.

Sign In Manager => https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.signinmanager-1?view=aspnetcore-2.1

## RoleManger

You can find out what roles a user has, if the user is in a role, and create Roles
with this class.

RoleManger = > https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.rolemanager-1?view=aspnetcore-2.1



